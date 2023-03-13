using System;
using System.Linq.Expressions;
using ConcentraVHM.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ConcentraVHM.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly ConcentraVHMContext _context;

        public BaseRepository(ConcentraVHMContext context) => _context = context;


        public virtual async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        
        public virtual async Task Update(T entity)
        {   
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
        }

        public virtual async Task<T>  Create(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
            _context.SaveChanges();
           return entity;
            
        }
        public async Task<bool> ExistsAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id) != null;
        }

        public async Task<T> FindByColumn(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}


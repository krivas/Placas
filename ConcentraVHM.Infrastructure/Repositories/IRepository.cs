using System;
using System.Linq.Expressions;

namespace ConcentraVHM.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Create(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<bool> ExistsAsync(object id);

        Task<T> FindByColumn(Expression<Func<T, bool>> predicate);


    }
}


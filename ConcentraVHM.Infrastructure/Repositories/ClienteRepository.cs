using System;
using ConcentraVHM.Domain.Entities;
using ConcentraVHM.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ConcentraVHM.Infrastructure.Repositories
{
	public class ClienteRepository : BaseRepository<Cliente>
	{
        private readonly ConcentraVHMContext _context;


        public ClienteRepository(ConcentraVHMContext context) : base(context)
        {
            _context = context;
        }

        public override Task Delete(Cliente entity)
        {
            var orden=_context.OrdenesPlacas.FirstOrDefault(x => x.Cliente.Cedula == entity.Cedula);

            if(orden!=null)
            _context.OrdenesPlacas.Remove(orden);
            
            var placas=_context.Placas.Where(x => x.Cliente.Cedula == entity.Cedula).ToList();
            if (placas!=null)
            _context.Placas.RemoveRange(placas);
          
            return base.Delete(entity);

        }
       

    }
}


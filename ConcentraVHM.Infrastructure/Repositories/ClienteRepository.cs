using System;
using ConcentraVHM.Domain.Entities;
using ConcentraVHM.Infrastructure.Context;

namespace ConcentraVHM.Infrastructure.Repositories
{
	public class ClienteRepository : BaseRepository<Cliente>
	{
        private readonly ConcentraVHMContext _context;

        public ClienteRepository(ConcentraVHMContext context) : base(context)
        {
        }
    }
}


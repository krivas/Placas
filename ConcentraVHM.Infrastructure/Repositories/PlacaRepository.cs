using System;
using System.Linq;
using System.Threading;
using ConcentraVHM.Domain.Entities;
using ConcentraVHM.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ConcentraVHM.Infrastructure.Repositories
{
    public class PlacaRepository : BaseRepository<Placa>,IBatchRepository<Placa> 
    {
        private readonly ConcentraVHMContext _context;



        public PlacaRepository(ConcentraVHMContext context) : base(context)
        {
            _context = context;
        }
        public async override Task<IEnumerable<Placa>> GetAll()
        {
            var placas = await _context.Placas
                .Include(e => e.TipoAutoMovil)
                .Include(e => e.Cliente)
                .AsNoTracking()
                .ToListAsync();

            return placas ?? new List<Placa>();
        }

        public async override Task Update(Placa placa)
        {
            try
            {
                var response = await GetAll();
                var entity = response.Where(x => x.Id == placa.Id).FirstOrDefault();
                var tipos = await _context.TiposAutoMovil.ToListAsync();
                var tipo = tipos.FirstOrDefault(x => x.Tipo == placa.TipoAutoMovil.Tipo);
                 if (entity != null)
                        {
                placa.Valor = tipo.Valor;
                 placa.Cliente = entity.Cliente;
                placa.TipoAutoMovil = tipo;

                _context.Placas.Update(placa);
                await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception( ex.Message);
            }
         
          
        }


        public async Task CreateBatch(Placa[] placas)
        {
            var tipos = await _context.TiposAutoMovil.ToListAsync();
            var cliente = _context.Clientes.FirstOrDefault(x => x.Cedula == placas[0].Cliente.Cedula);
           

            foreach (var item in placas)
            {
                var tipo = tipos.FirstOrDefault(x => x.Tipo == item.TipoAutoMovil.Tipo);
                item.Cliente = cliente;
                if (tipo != null)
                {
                    item.TipoAutoMovil = tipo;
                    item.Valor = tipo.Valor;
                    item.Fecha = DateTime.Now;
                }
                else
                {
                    throw new Exception();
                }
                
            }
            var ordenPlaca = new OrdenesPlacas();
            ordenPlaca.Cliente = cliente;
      
            ordenPlaca.Fecha = DateTime.Now;
            ordenPlaca.Total = placas.Sum(x=>x.Valor);

            await _context.Placas.AddRangeAsync(placas);
            await _context.OrdenesPlacas.AddAsync(ordenPlaca);

            await _context.SaveChangesAsync();


        }

        public  async Task<IEnumerable<Placa>> GetQuery(string query)
        {
            var response = await GetAll();
            if (!string.IsNullOrEmpty(query))
            {
               return  response.Where(x => x.Cliente.Cedula == query).ToList();

            }
            return response;
        }
    }
}


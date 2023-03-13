using System;
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
        
    }
}


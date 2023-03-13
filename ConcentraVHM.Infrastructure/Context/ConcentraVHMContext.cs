using System;
using System.Xml;
using ConcentraVHM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace ConcentraVHM.Infrastructure.Context
{
	public class ConcentraVHMContext : DbContext
	{
        public ConcentraVHMContext(DbContextOptions<ConcentraVHMContext> options)
          : base(options)
        {
        }
        

        public DbSet<Placa> Placas{ get; set; }
        public DbSet<TipoAutoMovil> TiposAutoMovil { get; set; }
        public DbSet<OrdenesPlacas> OrdenesPlacas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TipoAutoMovil>().HasData(
                new TipoAutoMovil { Id = 1, Tipo = 'A', Descripcion = "Publico", Valor = 100 },
                new TipoAutoMovil { Id = 2, Tipo = 'F', Descripcion = "Privado", Valor = 200 },
                new TipoAutoMovil { Id = 3, Tipo = 'T', Descripcion = "Transporte", Valor = 300 },
                new TipoAutoMovil { Id = 4, Tipo = 'P', Descripcion = "Pesado", Valor = 400 }
            );
        }

    }
}


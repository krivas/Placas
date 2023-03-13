using System;
using ConcentraVHM.Domain.Entities;
using ConcentraVHM.Infrastructure.Context;
using ConcentraVHM.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConcentraVHM.Infrastructure
{
	public static class  DataServicesRegistration
	{
        public static void AddDataServicesRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRepository<Cliente>, ClienteRepository>();
            services.AddTransient<IRepository<Placa>, PlacaRepository>();
            services.AddScoped<IBatchRepository<Placa>, PlacaRepository>();
            services.AddDbContext<ConcentraVHMContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
        }
    }
}


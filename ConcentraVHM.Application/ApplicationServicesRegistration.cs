using System;
using System.Reflection;
using ConcentraVHM.Application.Features.Clientes.Commands.CreateCliente;
using ConcentraVHM.Application.Features.Clientes.Commands.DeleteCliente;
using ConcentraVHM.Application.Features.Clientes.Commands.UpdateClient;
using ConcentraVHM.Application.Features.Clientes.Queries.GetClientes;
using ConcentraVHM.Application.Features.Placas.Commands.CreatePlaca;
using ConcentraVHM.Application.Features.Placas.Commands.DeletePlaca;
using ConcentraVHM.Application.Features.Placas.Commands.UpdatePlaca;
using ConcentraVHM.Application.Features.Placas.Queries.GetPlacas;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ConcentraVHM.Application
{
	public static class ApplicationServicesRegistration
    {
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(CreateClienteCommandHandler).Assembly);
            services.AddMediatR(typeof(UpdateClienteCommandHandler).Assembly);
            services.AddMediatR(typeof(DeleteClienteCommandHandler).Assembly);
            services.AddMediatR(typeof(GetClientesQueryHandler).Assembly);
            services.AddMediatR(typeof(CreatePlacaCommandHandler).Assembly);
            services.AddMediatR(typeof(UpdatePlacaCommandHandler).Assembly);
            services.AddMediatR(typeof(DeletePlacaCommandHandler).Assembly);
            services.AddMediatR(typeof(GetPlacasQueryHandler).Assembly);
            return services;
		}
	}
}


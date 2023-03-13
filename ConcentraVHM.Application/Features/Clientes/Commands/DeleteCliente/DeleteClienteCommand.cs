using System;
using MediatR;

namespace ConcentraVHM.Application.Features.Clientes.Commands.DeleteCliente
{
	public class DeleteClienteCommand : IRequest
    {
		public string Cedula { get; set; }

	}
}


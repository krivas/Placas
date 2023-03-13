
using ConcentraVHM.Domain.Entities;
using MediatR;
namespace ConcentraVHM.Application.Features.Clientes.Queries.GetClientes
{
	public class GetClientesQuery : IRequest<IEnumerable<Cliente>>
	{
		public GetClientesQuery()
		{
		}
	}
}


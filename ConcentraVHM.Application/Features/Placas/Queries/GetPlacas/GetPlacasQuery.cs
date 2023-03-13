using System;
using ConcentraVHM.Domain.Entities;
using MediatR;
namespace ConcentraVHM.Application.Features.Placas.Queries.GetPlacas
{
	public class GetPlacasQuery : IRequest<IEnumerable<Placa>>
	{
		
	}
}


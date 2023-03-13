using System;
using ConcentraVHM.Domain.DTOs;
using ConcentraVHM.Domain.Entities;
using MediatR;
namespace ConcentraVHM.Application.Features.Placas.Queries.GetPlacas
{
	public class GetPlacasQuery : IRequest<IEnumerable<PlacaDto>>
	{
		public string Cedula { get; set; }
	}
}


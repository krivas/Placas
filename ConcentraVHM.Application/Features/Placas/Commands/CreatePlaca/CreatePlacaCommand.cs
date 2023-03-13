using System;
using ConcentraVHM.Domain.DTOs;
using MediatR;
namespace ConcentraVHM.Application.Features.Placas.Commands
{
	public class CreatePlacaCommand :IRequest
	{
       public PlacaDto[] Placas { get; set; }
    }
}


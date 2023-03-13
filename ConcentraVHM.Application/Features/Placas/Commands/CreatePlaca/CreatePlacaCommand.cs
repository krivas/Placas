using System;
using ConcentraVHM.Domain.DTOs;
using MediatR;
namespace ConcentraVHM.Application.Features.Placas.Commands
{
	public class CreatePlacaCommand :IRequest
	{
       public PlacaInputDto[] Placas { get; set; }
    }
}


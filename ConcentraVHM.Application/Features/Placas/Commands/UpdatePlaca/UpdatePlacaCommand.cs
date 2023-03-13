using MediatR;
namespace ConcentraVHM.Application.Features.Placas.Commands.UpdatePlaca
{
    public class UpdatePlacaCommand : IRequest
    {
        public string Id{ get; set; }
    }
}


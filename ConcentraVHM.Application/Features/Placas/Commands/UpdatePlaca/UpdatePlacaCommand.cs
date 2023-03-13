using MediatR;
namespace ConcentraVHM.Application.Features.Placas.Commands.UpdatePlaca
{
    public class UpdatePlacaCommand : IRequest
    {
        public int Id { get; set; }
        public char TipoAutoMovil { get; set; }
        public string Cedula { get; set; }
    }
}


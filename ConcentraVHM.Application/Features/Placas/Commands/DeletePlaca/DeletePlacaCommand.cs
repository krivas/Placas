using MediatR;
namespace ConcentraVHM.Application.Features.Placas.Commands.DeletePlaca
{
	public class DeletePlacaCommand : IRequest
	{
		public int  Id { get; set; }
	}
}


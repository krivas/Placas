using AutoMapper;
using ConcentraVHM.Domain.Entities;
using ConcentraVHM.Infrastructure.Repositories;
using MediatR;
namespace ConcentraVHM.Application.Features.Placas.Commands.DeletePlaca
{
    public class DeletePlacaCommandHandler : IRequestHandler<DeletePlacaCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Placa> _clienteRepository;

        public DeletePlacaCommandHandler(IRepository<Placa> clienterepository, IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepository = clienterepository;
        }

        public async Task<Unit> Handle(DeletePlacaCommand request, CancellationToken cancellationToken)
        {
            var cliente = _mapper.Map<Placa>(request);
            await _clienteRepository.Delete(cliente);
            return Unit.Value;
        }
    }
}


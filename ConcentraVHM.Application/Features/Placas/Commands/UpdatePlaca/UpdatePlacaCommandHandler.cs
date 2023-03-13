using System;
using AutoMapper;
using ConcentraVHM.Domain.Entities;
using ConcentraVHM.Infrastructure.Repositories;
using MediatR;

namespace ConcentraVHM.Application.Features.Placas.Commands.UpdatePlaca
{
	public class UpdatePlacaCommandHandler : IRequestHandler<UpdatePlacaCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Placa> _placaRepository;

        public UpdatePlacaCommandHandler(IRepository<Placa> placaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _placaRepository = placaRepository;
        }


        public async Task<Unit> Handle(UpdatePlacaCommand request, CancellationToken cancellationToken)
        {
                var cliente = _mapper.Map<Placa>(request);
                await _placaRepository.Update(cliente);
                return Unit.Value;
         }
        
    }
}


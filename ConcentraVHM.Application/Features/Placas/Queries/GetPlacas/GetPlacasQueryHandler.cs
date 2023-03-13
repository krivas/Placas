using System;
using AutoMapper;
using ConcentraVHM.Application.Features.Placas.Commands.DeletePlaca;
using ConcentraVHM.Domain.Entities;
using ConcentraVHM.Infrastructure.Repositories;
using MediatR;

namespace ConcentraVHM.Application.Features.Placas.Queries.GetPlacas
{
	public class GetPlacasQueryHandler : IRequestHandler<GetPlacasQuery,IEnumerable<Placa>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Placa> _clienteRepository;

        public GetPlacasQueryHandler(IRepository<Placa> clienterepository, IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepository = clienterepository;
        }

        public async Task<IEnumerable<Placa>> Handle(GetPlacasQuery request, CancellationToken cancellationToken)
        {
            var cliente = _mapper.Map<Placa>(request);
            return await _clienteRepository.GetAll();

        }
    }

}


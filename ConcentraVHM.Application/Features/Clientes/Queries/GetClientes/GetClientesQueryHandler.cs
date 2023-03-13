using System;
using AutoMapper;
using ConcentraVHM.Application.Features.Placas.Queries.GetPlacas;
using ConcentraVHM.Domain.Entities;
using ConcentraVHM.Infrastructure.Repositories;
using MediatR;

namespace ConcentraVHM.Application.Features.Clientes.Queries.GetClientes
{
	public class GetClientesQueryHandler : IRequestHandler<GetClientesQuery,IEnumerable<Cliente>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Cliente> _clienteRepository;

        public GetClientesQueryHandler(IRepository<Cliente> clienterepository, IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepository = clienterepository;
        }

        public async Task<IEnumerable<Cliente>> Handle(GetClientesQuery request, CancellationToken cancellationToken)
        {
            return await _clienteRepository.GetAll();
        }
    }

   
	
}


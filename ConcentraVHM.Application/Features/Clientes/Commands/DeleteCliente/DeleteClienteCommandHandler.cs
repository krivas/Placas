using System;
using System.Globalization;
using AutoMapper;
using ConcentraVHM.Application.Features.Clientes.Commands.CreateCliente;
using ConcentraVHM.Domain.Entities;
using ConcentraVHM.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
namespace ConcentraVHM.Application.Features.Clientes.Commands.DeleteCliente
{
	public class DeleteClienteCommandHandler:IRequestHandler<DeleteClienteCommand>
	{
		
        private readonly IMapper _mapper;
        private readonly IRepository<Cliente> _clienteRepository;

        public DeleteClienteCommandHandler(IRepository<Cliente> clienterepository, IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepository = clienterepository;
        }

        public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteClienteCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var cliente = _mapper.Map<Cliente>(request);
            var exists=await _clienteRepository.ExistsAsync(cliente.Cedula);
            if (exists)
            await _clienteRepository.Delete(cliente);
            return Unit.Value;
        }

        public partial class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<DeleteClienteCommand, Cliente>().ReverseMap();
            }
        }

        public class DeleteClienteCommandValidator : AbstractValidator<DeleteClienteCommand>
        {
            public DeleteClienteCommandValidator()
            {
                RuleFor(p => p.Cedula)
                  .NotEmpty().WithMessage("{Cedula} es requerido")
                  .NotNull().WithMessage("{Cedula} no puedo ser nulo")
                  .Length(11).WithMessage("{Cedula} debe ser 11 digitos");


            }

        }

    }
}


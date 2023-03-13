using System;
using AutoMapper;
using ConcentraVHM.Application.Features.Clientes.Commands.CreateCliente;
using ConcentraVHM.Domain.Entities;
using ConcentraVHM.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using System.Globalization;

namespace ConcentraVHM.Application.Features.Clientes.Commands.UpdateClient
{
	public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Cliente> _clienteRepository;

        public UpdateClienteCommandHandler(IRepository<Cliente> clienterepository, IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepository = clienterepository;
        }


        public async Task<Unit> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateClienteCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var cliente = _mapper.Map<Cliente>(request);
            var exists=await _clienteRepository.ExistsAsync(cliente.Cedula);
            if (exists==false)
                throw new Exceptions.NotFoundException("Cliente","cedula");

            await _clienteRepository.Update(cliente);

            return Unit.Value;
        }

        public partial class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<UpdateClienteCommand, Cliente>().ReverseMap();
            }
        }

        public class UpdateClienteCommandValidator : AbstractValidator<UpdateClienteCommand>
        {
            public UpdateClienteCommandValidator()
            {
                RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{Nombre} es requerido")
                .NotNull().WithMessage("{Nombre} no puedo ser nulo")
                .MinimumLength(2).WithMessage("{Nombre} minimo 3 letras"); ;


                RuleFor(p => p.Apellido)
                .NotEmpty().WithMessage("{Apellido} es requerido")
                .NotNull().WithMessage("{Apellido} no puedo ser nulo")
                .MinimumLength(2).WithMessage("{Apellido} minimo 3 letras"); ; ;

                RuleFor(p => p.Cedula)
                .NotEmpty().WithMessage("{Cedula} es requerido")
                .NotNull().WithMessage("{Cedula} no puedo ser nulo")
                .Length(11).WithMessage("{Cedula} debe ser 11 digitos");

                RuleFor(p => p.FechaNacimiento)
                .NotEmpty().WithMessage("{Fecha Nacimiento} es requerido")
                .NotNull().WithMessage("{Fecha Nacimiento} no puedo ser nulo")
                .Must(fechaNacimiento => IsFechaNacimientoCorrectFormat(fechaNacimiento))
                .WithMessage("Fecha de nacimiento debe estar en el formato 'yyyy-MM-dd'.");

                RuleFor(p => p.TipoPersona)
                .NotEmpty().WithMessage("{Tipo de persona} es requerido")
                .NotNull().WithMessage("{Tipo de persona} no puedo ser nulo")
                .Must(tipoPersona => tipoPersona == 'F' || tipoPersona == 'J');

            }

            private bool IsFechaNacimientoCorrectFormat(string input)
            {
                DateTime date;
                return DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

            }
        }

	
	
	}
}


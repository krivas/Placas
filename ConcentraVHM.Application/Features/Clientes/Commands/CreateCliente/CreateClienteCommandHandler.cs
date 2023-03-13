using System;
using System.Globalization;
using AutoMapper;
using ConcentraVHM.Domain.Entities;
using ConcentraVHM.Infrastructure.Repositories;
using FluentValidation;
using MediatR;

namespace ConcentraVHM.Application.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Cliente> _clienteRepository;

        public CreateClienteCommandHandler(IRepository<Cliente> clienterepository, IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepository = clienterepository;
        }

        public async Task<string> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateClienteCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var cliente = _mapper.Map<Cliente>(request);
                cliente = await _clienteRepository.Create(cliente);

            return cliente.Cedula;

        }

        public partial class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<CreateClienteCommand, Cliente>().ReverseMap();
            }
        }

        public class CreateClienteCommandValidator: AbstractValidator<CreateClienteCommand>
        {
            public CreateClienteCommandValidator()
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


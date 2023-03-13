using System;
using AutoMapper;
using ConcentraVHM.Application.Features.Clientes.Commands.CreateCliente;
using ConcentraVHM.Domain.DTOs;
using ConcentraVHM.Domain.Entities;
using ConcentraVHM.Infrastructure.Repositories;
using FluentValidation;
using MediatR;

namespace ConcentraVHM.Application.Features.Placas.Commands.CreatePlaca
{
    public class CreatePlacaCommandHandler : IRequestHandler<CreatePlacaCommand>
    {
        private readonly IMapper _mapper;
        private readonly IBatchRepository<Placa> _placaBatchRepository;
        private readonly IRepository<Cliente> _clienteRepository;
        

        public CreatePlacaCommandHandler(IRepository<Cliente> clienteRepository,IBatchRepository<Placa> placaBatchRepository, IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
            _placaBatchRepository = placaBatchRepository;
        }

        public async Task<Unit> Handle(CreatePlacaCommand request, CancellationToken cancellationToken)
        {
            var validator = new PlacasValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var placas= _mapper.Map<Placa[]>(request.Placas);

            var exists=await _clienteRepository.ExistsAsync(placas[0].Cliente.Cedula);
            if (exists == false)
                throw new Exceptions.NotFoundException("Placa", "cedula");

            await _placaBatchRepository.CreateBatch(placas);
            return Unit.Value;
        }

        public partial class MappingProfile : Profile
        {
            public MappingProfile()
            {

                CreateMap<PlacaDto, Placa>()
                .ForMember(dest => dest.TipoAutoMovil, opt => opt.MapFrom(src => new TipoAutoMovil
                {
                    Tipo = src.TipoAutoMovil,
               }))
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => new Cliente
                {
         
                  Cedula = src.Cedula,
                  
                }));


            }
        }

        public class PlacasValidator : AbstractValidator<CreatePlacaCommand>
        {
            public PlacasValidator()
            {
                RuleForEach(x => x.Placas)
            .SetValidator(new PlacaValidator());
            }
        }

        public class PlacaValidator : AbstractValidator<PlacaDto>
        {
            public PlacaValidator()
            {
             
                RuleFor(p => p.TipoAutoMovil)
                .NotEmpty().WithMessage("{Tipo de auto movil} es requerido")
                .NotNull().WithMessage("{Tipo de auto movil} no puedo ser nulo")
                .Must(x => x == 'A' || x == 'T' || x == 'P' || x == 'F')
                .WithMessage("El tipo de auto movil debe ser A, T, P or F");

                RuleFor(p => p.Cedula)
               .NotEmpty().WithMessage("{Cedula} es requerido")
               .NotNull().WithMessage("{Cedula} no puedo ser nulo")
               .Length(11).WithMessage("{Cedula} debe ser 11 digitos");
            }

            
        }
    }

}


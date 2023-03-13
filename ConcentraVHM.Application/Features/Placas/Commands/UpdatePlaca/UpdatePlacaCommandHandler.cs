using System;
using AutoMapper;
using ConcentraVHM.Application.Features.Placas.Commands.DeletePlaca;
using ConcentraVHM.Domain.DTOs;
using ConcentraVHM.Domain.Entities;
using ConcentraVHM.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using static ConcentraVHM.Application.Features.Clientes.Commands.UpdateClient.UpdateClienteCommandHandler;

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
            var validator = new UpdatePlacaCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);
            var placa = _mapper.Map<Placa>(request);
                var exists=await _placaRepository.ExistsAsync(placa.Id);
                if(exists)
                await _placaRepository.Update(placa);
                else
                throw new Exceptions.NotFoundException("Cliente", "cedula");
            return Unit.Value;
         }


        
    }

    public partial class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<UpdatePlacaCommand, Placa>()
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

    public class UpdatePlacaCommandValidator : AbstractValidator<UpdatePlacaCommand>
    {
        public UpdatePlacaCommandValidator()
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

            RuleFor(p => p.Id)
          .NotEmpty().WithMessage("{Cedula} es requerido")
          .NotNull().WithMessage("{Cedula} no puedo ser nulo");
        }


    }
}


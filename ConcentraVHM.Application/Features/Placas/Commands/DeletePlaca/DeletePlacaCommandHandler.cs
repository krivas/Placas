using AutoMapper;
using ConcentraVHM.Application.Features.Clientes.Commands.DeleteCliente;
using ConcentraVHM.Domain.DTOs;
using ConcentraVHM.Domain.Entities;
using ConcentraVHM.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using static ConcentraVHM.Application.Features.Clientes.Commands.CreateCliente.CreateClienteCommandHandler;

namespace ConcentraVHM.Application.Features.Placas.Commands.DeletePlaca
{
    public class DeletePlacaCommandHandler : IRequestHandler<DeletePlacaCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Placa> _placaRepository;

        public DeletePlacaCommandHandler(IRepository<Placa> placarepository, IMapper mapper)
        {
            _mapper = mapper;
            _placaRepository = placarepository;
        }

        public async Task<Unit> Handle(DeletePlacaCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeletePlacaCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);
            var cliente = _mapper.Map<Placa>(request);
            var exists = await _placaRepository.ExistsAsync(cliente.Id);
            if (exists)
                await _placaRepository.Delete(cliente);

            return Unit.Value;
        }
        public class DeletePlacaCommandValidator : AbstractValidator<DeletePlacaCommand>
        {
            public DeletePlacaCommandValidator()
            {
                RuleFor(p => p.Id)
                  .NotEmpty().WithMessage("{Id} es requerido")
                  .NotNull().WithMessage("{Id} no puedo ser nulo");

            }

        }
        public partial class MappingProfile : Profile
        {
            public MappingProfile()
            {

                CreateMap<DeletePlacaCommand, Placa>();
                


            }
        }
    }
}


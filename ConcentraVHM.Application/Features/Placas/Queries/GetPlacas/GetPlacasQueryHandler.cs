using System;
using AutoMapper;
using ConcentraVHM.Application.Features.Clientes.Commands.UpdateClient;
using ConcentraVHM.Application.Features.Placas.Commands.DeletePlaca;
using ConcentraVHM.Domain.DTOs;
using ConcentraVHM.Domain.Entities;
using ConcentraVHM.Infrastructure.Repositories;
using MediatR;

namespace ConcentraVHM.Application.Features.Placas.Queries.GetPlacas
{
	public class GetPlacasQueryHandler : IRequestHandler<GetPlacasQuery,IEnumerable<PlacaDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISearch<Placa> _searchPlacas;

        public GetPlacasQueryHandler(ISearch<Placa> searchPlacas, IMapper mapper)
        {
            _mapper = mapper;
            _searchPlacas = searchPlacas;
        }

        public async Task<IEnumerable<PlacaDto>> Handle(GetPlacasQuery request, CancellationToken cancellationToken)
        {
            var placas=await _searchPlacas.GetQuery(request.Cedula);
            return _mapper.Map<PlacaDto[]>(placas);



        }
    }
    public partial class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Placa, PlacaDto>()
            .ForMember(dest => dest.TipoAutoMovil, opt => opt.MapFrom(src => src.TipoAutoMovil.Tipo))
            .ForMember(dest => dest.Cedula, opt => opt.MapFrom(src => src.Cliente.Cedula))
             .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fecha.ToString("yyyy-MM-dd")));


        }
    }
}


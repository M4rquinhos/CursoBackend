using AutoMapper;
using CursoBackend.DTOs;
using CursoBackend.Models;

namespace CursoBackend.Automappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BeerInsertDto, Beer>();
            CreateMap<Beer, BeerDto>()
                .ForMember(dto => dto.Id,
                           m => m.MapFrom(b => b.BeerId));
            CreateMap<BeerUpdateDto, Beer>();
        }
    }
}

using AutoMapper;
using MiPrimeraApiRest.DTOS;
using MiPrimeraApiRest.Modelos;

namespace MiPrimeraApiRest
{
    public class MappinConfig : Profile
    {
        public MappinConfig()
        {
            CreateMap<Villa, VillaDto>().ReverseMap();
            CreateMap<Villa, VillaDtoCreate>().ReverseMap();
            CreateMap<Villa, VillaDtoUpdate>().ReverseMap();
        }
    }
}

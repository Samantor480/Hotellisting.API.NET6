using AutoMapper;
using HotellistingApi.Data;
using HotellistingApi.Models.Country;
using HotellistingApi.Models.Hotels;

namespace HotellistingApi.Configurations
{
    public class MapperConfig:Profile 
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, GetCountryDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();

            CreateMap<Hotel,HotelDto>().ReverseMap();
        }

    }
}

using AutoMapper;
using HotellistingApi.Data;
using Hotellisting.Api.Core.Models.Country;
using Hotellisting.Api.Core.Models.Hotels;
using Hotellisting.Api.Core.Models.Users;

namespace Hotellisting.Api.Core.Configurations
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
            CreateMap<Hotel,CreateHotelDto>().ReverseMap();


            CreateMap<ApiUserDto,ApiUser>().ReverseMap();
        }

    }
}

using Hotellisting.Api.Core.Models.Country;
using HotellistingApi.Data;

namespace Hotellisting.Api.Core.Contracts
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        Task<CountryDto> GetDetails(int id);
    }
}

using Delegate.Api.Dtos;

namespace Delegate.Api.Services
{
    public interface ICountryService
    {
        Task<Response<CountryDto>> GetCountriesAsync();
    }
}

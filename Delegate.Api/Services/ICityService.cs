using Delegate.Api.Dtos;

namespace Delegate.Api.Services
{
    public interface ICityService
    {
        Task<Response<CityDto>> GetCitiesAsync();
    }
}

using Delegate.Api.Dtos;

namespace Delegate.Api.Services
{
    public interface IRequestService
    {
        Task<Response<TDto>> RequestAsync<TDto>(string url, Func<Response<TDto>, Task<Response<TDto>>> func);
    }
}

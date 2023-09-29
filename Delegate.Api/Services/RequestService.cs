using Delegate.Api.Dtos;

namespace Delegate.Api.Services
{
    public class RequestService : IRequestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RequestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Response<TDto>> RequestAsync<TDto>(string url, Func<Response<TDto>, Task<Response<TDto>>> func)
        {
            var client = _httpClientFactory.CreateClient();

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "X-Parse-Application-Id", "mxsebv4KoWIGkRntXwyzg6c6DhKWQuit8Ry9sHja" },
                    { "X-Parse-Master-Key", "TpO0j3lG2PmEVMXlKYQACoOXKQrL3lwM0HwR9dbH" },
                },
            };

            using var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<TDto>>(json);

            return await func(data);
        }
    }
}

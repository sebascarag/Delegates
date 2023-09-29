using Delegate.Api.Dtos;
using Delegate.Api.Entities;
using Delegate.Api.Repositories;

namespace Delegate.Api.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> _repository;
        private readonly IRequestService _request;
        private readonly string _url;

        public CountryService(IRequestService request, IRepository<Country> repository)
        {
            _request = request;
            _repository = repository;
            _url = "https://parseapi.back4app.com/classes/Country?limit=10";
        }

        public async Task<Response<CountryDto>> GetCountriesAsync()
        {
            var data = await _request.RequestAsync<CountryDto>(_url, this.CreateCountries); // delegate with function
            return data;
        }

        public async Task<Response<CountryDto>> CreateCountries(Response<CountryDto> data)
        {
            var countryList = data.Results.Select(x => new Country()
            {
                Capital = x.Capital,
                ClassName = x.ClassName,
                Code = x.Code,
                Currency = x.Currency,
                Name = x.Name,
                Native = x.Native,
                ObjectId = x.ObjectId,
                Phone = x.Phone
            }).ToList();

            await _repository.Add(countryList);

            return data;
        }
    }
}

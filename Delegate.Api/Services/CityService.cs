using Delegate.Api.Dtos;
using Delegate.Api.Entities;
using Delegate.Api.Repositories;

namespace Delegate.Api.Services
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> _repository;
        private readonly IRequestService _request;
        private readonly string _url;

        public CityService(IRepository<City> repository, IRequestService request)
        {
            _request = request;
            _repository = repository;
            _url = "https://parseapi.back4app.com/classes/City?limit=10";
        }

        public async Task<Response<CityDto>> GetCitiesAsync()
        {
            var result = await _request.RequestAsync<CityDto>(_url, async data => // delegate with lambda funtion
            {
                var cityList = data.Results.Select(x => new City()
                {
                    AdminCode = x.AdminCode,
                    AltName = x.AltName,
                    CityId = x.CityId,
                    Country = new Country()
                    {
                        ClassName = x.Country.ClassName,
                        ObjectId = x.Country.ObjectId,
                    },
                    Name = x.Name,
                    ObjectId = x.ObjectId,
                    Population = x.Population
                }).ToList();

                await _repository.Add(cityList);

                return data;

            });

            return result;
        }
    }
}

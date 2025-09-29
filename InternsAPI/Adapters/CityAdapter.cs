using Jalasoft.Interns.Service.Domain.Cities;
using Jalasoft.Interns.API.Requests.Cities;
using Jalasoft.Interns.API.Responses.Cities;

namespace Jalasoft.Interns.API.Adapter
{
    public interface ICityAdapter
    {
        public City AdaptCityDtoToCity(CityResponseDto city);
        public CityResponseDto AdaptCityToCityDto(City city);
        public City AdaptUpdateCityToCity(UpdateCityRequestDto city);
        public City AdaptCreateCityDtoToCity(CreateCityRequestDto city);

    }
    public class CityAdapter : ICityAdapter
    {
        public City AdaptCityDtoToCity(CityResponseDto city)
        {
            return new City()
            {
                Id = city.Id,
                Name = city.Name,
                Capital = city.Capital,
                Country = city.Country,
                GPD = city.GPD,
                Capitalist= city.Capitalist,
                Hospitals = city.Hospitals,
            };
        }

        public CityResponseDto AdaptCityToCityDto(City city)
        {
            return new CityResponseDto()
            {
                Id = city.Id,
                Name = city.Name,
                Capital = city.Capital,
                Country = city.Country,
                GPD = city.GPD,
                Capitalist = city.Capitalist,
                Hospitals = city.Hospitals,
            };
        }
        public City AdaptCreateCityDtoToCity(CreateCityRequestDto city)
        {
            return new City()
            {
                Name = city.Name,
                Capital = city.Capital,
                Country = city.Country,
                GPD = city.GPD,
                Capitalist = city.Capitalist,
                Hospitals = Enumerable.Empty<Hospital>(),

            };
        }

        public City AdaptUpdateCityToCity(UpdateCityRequestDto city)
        {
            return new City()
            {
                Name = city.Name,
                Capital = city.Capital,
                Country = city.Country,
                GPD = city.GPD,
                Capitalist = city.Capitalist,
                Hospitals = city.Hospitals,
            };
        }
    }
}

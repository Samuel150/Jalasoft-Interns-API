using Jalasoft.Interns.Service.Domain.Cities;
using Jalasoft.Interns.API.Requests.Cities;
using Jalasoft.Interns.API.Responses.Cities;

namespace Jalasoft.Interns.API.Adapter
{
    public interface ICityAdapter
    {
        public City AdaptCityDtoToCity(DefaultCityResponseDto city);
        public DefaultCityResponseDto AdaptCityToCityDto(City city);
        public City AdaptUpdateCityToCity(UpdateCityRequestDto city);
        public City AdaptCreateCityDtoToCity(CreateCityRequestDto city);

    }
    public class CityAdapter : ICityAdapter
    {
        public City AdaptCityDtoToCity(DefaultCityResponseDto city)
        {
            Console.WriteLine(city.Id);

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

        public DefaultCityResponseDto AdaptCityToCityDto(City city)
        {
            return new DefaultCityResponseDto()
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
                Hospitals = MapHospitalsFromRequest(city.Hospitals),

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
        private IList<Hospital> MapHospitalsFromRequest(IList<CreateHospitalRequestDto> hospitals)
        {
            if (hospitals == null || !hospitals.Any())
                return new List<Hospital>();

            return hospitals.Select(h => new Hospital()
            {
                Name = h.Name,
                Address = h.Address
            }).ToList();
        }
    }
}

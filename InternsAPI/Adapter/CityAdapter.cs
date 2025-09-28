using Jalasoft.Interns.Service.Domain.Cities;
using Jalasoft.Interns.API.Requests.Cities;
using Jalasoft.Interns.API.Responses.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalasoft.Interns.API.Adapter
{
    public interface ICityAdapter
    {
        public City AdaptCityDtoToCity(CityDto city);
        public CityDto AdaptCityToCityDto(City city);
        public City AdaptUpdateCityToCity(UpdateCityDto city);
        public City AdaptCreateCityDtoToCity(CreateCityDto city);

    }
    public class CityAdapter : ICityAdapter
    {
        public City AdaptCityDtoToCity(CityDto city)
        {
            return new City()
            {
                Id = city.Id,
                Name = city.Name,
                Capital = city.Capital,
                Country = city.Country,
                GPD = city.GPD,
                Capitalist= city.Capitalist,
            };
        }

        public CityDto AdaptCityToCityDto(City city)
        {
            return new CityDto()
            {
                Id = city.Id,
                Name = city.Name,
                Capital = city.Capital,
                Country = city.Country,
                GPD = city.GPD,
                Capitalist = city.Capitalist,
            };
        }
        public City AdaptCreateCityDtoToCity(CreateCityDto city)
        {
            return new City()
            {
                Name = city.Name,
                Capital = city.Capital,
                Country = city.Country,
                GPD = city.GPD,
                Capitalist = city.Capitalist,
            };
        }

        public City AdaptUpdateCityToCity(UpdateCityDto city)
        {
            return new City()
            {
                Name = city.Name,
                Capital = city.Capital,
                Country = city.Country,
                GPD = city.GPD,
                Capitalist = city.Capitalist,
            };
        }
    }
}

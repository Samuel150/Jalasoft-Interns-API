using Jalasoft.Interns.Service.Domain.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalasoft.Interns.Service.PatchHelpers.Cities
{
    public class PatchCityHelper
    {
        public static PatchCity CityToPatchCity(City city)
        {
            return new PatchCity()
            {
                Name = city.Name,
                Capital = city.Capital,
                Country = city.Country,
                GPD = city.GPD,
                Capitalist = city.Capitalist,
                Hospitals = city.Hospitals,
            };
        }
        public static City PatchCityToCity(PatchCity patch, int id)
        {
            return new City()
            {
                Id = id,
                Name = patch.Name,
                Capital = patch.Capital,
                Country = patch.Country,
                GPD = patch.GPD,
                Capitalist = patch.Capitalist,
                Hospitals = patch.Hospitals,
            };

        }
    }
}

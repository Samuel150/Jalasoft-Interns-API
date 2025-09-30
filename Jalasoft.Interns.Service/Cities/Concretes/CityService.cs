using FluentValidation;
using Jalasoft.Interns.Service.Cities.Interfaces;
using Jalasoft.Interns.Service.Domain.Cities;
using Jalasoft.Interns.Service.PatchHelpers.Cities;
using Jalasoft.Interns.Service.RepositoryInterfaces;
using Jalasoft.Interns.Service.Validators.Cities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalasoft.Interns.Service.Cities.Concretes
{
    public class CityService(ICityRepository _cityRepository, CityValidator cityValidator) : ICityService
    {
        public City Create(City city)
        {
            cityValidator.ValidateAndThrow(city);
            return _cityRepository.Create(city);
        }

        public IEnumerable<City> GetAll(bool capitalist)
        {
            return _cityRepository.GetAll(capitalist);
        }

        public City GetById(int id)
        {
            return _cityRepository.GetById(id);
        }

        public City Patch(JsonPatchDocument<PatchCity> patchCity, int id)
        {
            City? city  = _cityRepository.GetById(id);
            if (city == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                PatchCity patchCity1 = PatchCityHelper.CityToPatchCity(city);
                patchCity.ApplyTo(patchCity1);
                _cityRepository.Update(id, PatchCityHelper.PatchCityToCity(patchCity1, id));
                return PatchCityHelper.PatchCityToCity(patchCity1, id); 
            }
        }

        public City Update(int id, City city)
        {
            var cityExists = _cityRepository.GetById(id);
            if (cityExists == null)
            {
                throw new Exception("The City does not exists");
            }
            var updatedCity = _cityRepository.Update(id, city);      
            return updatedCity;
        }
    }
}

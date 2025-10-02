using FluentValidation;
using Jalasoft.Interns.Service.Cities.Interfaces;
using Jalasoft.Interns.Service.Domain.Cities;
using Jalasoft.Interns.Service.Exceptions;
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
            //cityValidator.ValidateAndThrow(city);
            return _cityRepository.Create(city);
        }

        public IEnumerable<City> GetAll(bool capitalist)
        {
            return _cityRepository.GetAll(capitalist);
        }

        public City GetById(int id)
        {
            City? city = _cityRepository.GetById(id);
            if (city == null)
            {
                throw new CityNotFoundException(id);
            }
            return city;
        }

        public City Patch(JsonPatchDocument<PatchCity> patchCity, int id)
        {
            City? city = _cityRepository.GetById(id);
            if (city == null)
            {
                throw new CityNotFoundException(id);
            }

            PatchCity patchCity1 = PatchCityHelper.CityToPatchCity(city);
            patchCity.ApplyTo(patchCity1);
            City updatedCity = PatchCityHelper.PatchCityToCity(patchCity1, id);
            //cityValidator.ValidateAndThrow(updatedCity);
            _cityRepository.Update(id, updatedCity);
            return updatedCity;
        }

        public City Update(int id, City city)
        {
            var cityExists = _cityRepository.GetById(id);
            if (cityExists == null)
            {
                throw new CityNotFoundException(id);
            }

            //cityValidator.ValidateAndThrow(city);
            var updatedCity = _cityRepository.Update(id, city);
            return updatedCity;
        }
        public void Delete(int id)
        {
            var city = _cityRepository.GetById(id);
            if (city == null)
            {
                throw new CityNotFoundException(id);
            }

            _cityRepository.Delete(id);
        }

        public Hospital AddHospital(int cityId, Hospital hospital)
        {
            var city = _cityRepository.GetById(cityId);
            if (city == null)
            {
                throw new CityNotFoundException(cityId);
            }

            var addedHospital = _cityRepository.AddHospital(cityId, hospital);
            return addedHospital;
        }

        public IEnumerable<Hospital> GetHospitalsByCityId(int cityId)
        {
            var city = _cityRepository.GetById(cityId);
            if (city == null)
            {
                throw new CityNotFoundException(cityId);
            }

            var hospitals = _cityRepository.GetHospitalsByCityId(cityId);
            return hospitals ?? new List<Hospital>();
        }
    }
}

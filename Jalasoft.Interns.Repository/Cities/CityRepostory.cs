using Jalasoft.Interns.Service.Domain.Cities;
using Jalasoft.Interns.Service.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalasoft.Interns.Repository.Cities
{
    public class CityRepository : ICityRepository
    {
        private readonly Dictionary<int, City> _cities = new Dictionary<int, City>()
        {
            {1, new City() {Id=1, Name = "Cochabamba", GPD=1000, Country="Bolivia", Capital="Cochabamba", Capitalist= true, Hospitals = [
                new Hospital(){Id=1, Name="Viedma", Address= "Av. Suecia"},
                new Hospital(){Id=2, Name="Alamo", Address= "Av. Suecia 2"},
                ] } },
            {2, new City() {Id=2,Name = "Tarija", GPD=1000, Country="Bolivia", Capital="Cercado", Capitalist= true, Hospitals = [
                new Hospital(){Id=1, Name="Viedma Tarija", Address= "Av. Suecia"},
                ] } },
            {3, new City() {Id=3,Name = "Pando", GPD=1000, Country="Bolivia", Capital="Cercado", Capitalist= true}}
        };
        private int _nextId = 3;
        private int _nextHospitalId = 0;
        public City Create(City city)
        {
            city.Id = ++_nextId;
            if (city.Hospitals != null && city.Hospitals.Any())
            {
                city.Hospitals = AssignHospitalIds(city.Hospitals);
            }
            else
            {
                city.Hospitals = new List<Hospital>();
            }
            _cities.Add(city.Id, city);
            return city;

        }

        public List<City> GetAll(bool capitalist)
        {
            return _cities.Values.Where(v => v.Capitalist == capitalist).ToList();
        }

        public City GetById(int id)
        {
            if (_cities.TryGetValue(id, out City foudCity))
            {
                return foudCity;
            }
            return null;
        }

        public City Update(int id, City city)
        {
            if (_cities.TryGetValue(id, out City foudCity))
            {
                foudCity.Name = city.Name;
                foudCity.Capital = city.Capital;
                foudCity.GPD = city.GPD;
                foudCity.Country = city.Country;
                foudCity.Hospitals = city.Hospitals;
                return foudCity;
            }
            return null;
            
        }
        private IList<Hospital> AssignHospitalIds(IList<Hospital> hospitals)
        {
            return hospitals.Select(hospital => new Hospital
            {
                Id = hospital.Id == 0 ? ++_nextHospitalId : hospital.Id,
                Name = hospital.Name,
                Address = hospital.Address
            }).ToList();
        }
        public bool Delete(int id)
        {
            if (_cities.ContainsKey(id))
            {
                return _cities.Remove(id);
            }
            return false;
        }

        public Hospital AddHospital(int cityId, Hospital hospital)
        {
            if (_cities.TryGetValue(cityId, out City city))
            {
                if (city.Hospitals == null)
                {
                    city.Hospitals = new List<Hospital>();
                }

                hospital.Id = ++_nextHospitalId;
                city.Hospitals.Add(hospital);
                return hospital;
            }
            return null;
        }

        public Hospital GetHospitalById(int cityId, int hospitalId)
        {
            if (_cities.TryGetValue(cityId, out City city))
            {
                if (city.Hospitals != null)
                {
                    return city.Hospitals.FirstOrDefault(h => h.Id == hospitalId);
                }
            }
            return null;
        }

        public List<Hospital> GetHospitalsByCityId(int cityId)
        {
            if (_cities.TryGetValue(cityId, out City city))
            {
                return city.Hospitals?.ToList() ?? new List<Hospital>();
            }
            return null;
        }
    }
}

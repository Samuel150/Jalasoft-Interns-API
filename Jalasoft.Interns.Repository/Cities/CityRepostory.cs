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
            {1, new City() {Name = "Cochabamba", GPD=1000, Country="Bolivia", Capital="Cochabamba", Capitalist= true, Hospitals = [
                new Hospital(){Id=1, Name="Viedma", Address= "Av. Suecia"},
                new Hospital(){Id=2, Name="Alamo", Address= "Av. Suecia 2"},
                ] } },
            {2, new City() {Name = "Tarija", GPD=1000, Country="Bolivia", Capital="Cercado", Capitalist= true, Hospitals = [
                new Hospital(){Id=1, Name="Viedma Tarija", Address= "Av. Suecia"},
                ] } },
            {3, new City() {Name = "Pando", GPD=1000, Country="Bolivia", Capital="Cercado", Capitalist= true}}
        };
        private int _nextId = 3;
        public City Create(City city)
        {
            city.Id = ++_nextId;
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
    }
}

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
        private readonly Dictionary<int, City> _cities = new Dictionary<int, City>();
        private int _nextId = 0;
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
                return foudCity;
            }
            return null;
            
        }
    }
}

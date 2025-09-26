using Jalasoft.Interns.Service.Domain.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalasoft.Interns.Service.RepositoryInterfaces
{
    public interface ICityRepository
    {
        public City GetById(int id);
        public List<City> GetAll(bool capitalist);
        public City Create(City city);
        public City Update(int id, City city);
    }
}

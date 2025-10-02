using Jalasoft.Interns.Service.Domain.Cities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalasoft.Interns.Service.Cities.Interfaces
{
    public interface ICityService
    {
        public City GetById(int id);
        public IEnumerable<City> GetAll(bool capitalist);
        public City Create(City city);
        public City Update(int id, City city);
        public City Patch(JsonPatchDocument<PatchCity> patchCity, int id);
        public void Delete(int id);
        public Hospital AddHospital(int cityId, Hospital hospital);
        public IEnumerable<Hospital> GetHospitalsByCityId(int cityId);
    }
}

using Jalasoft.Interns.Service.Domain.Employees;
using Microsoft.AspNetCore.JsonPatch;

namespace Jalasoft.Interns.Service.Employees
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> RetrieveEmployees(bool active);

        public Employee RetrieveEmployee(int id);

        public Employee CreateEmployee(Employee employee);

        public Employee PatchEmployee(JsonPatchDocument<PatchEmployee> patchDocument, int id);
    }
}

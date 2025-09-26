using Jalasoft.Interns.Service.Domain.Employees;

namespace Jalasoft.Interns.Service.Employees
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> RetrieveEmployees(bool active);
    }
}

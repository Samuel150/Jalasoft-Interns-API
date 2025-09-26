using Jalasoft.Interns.Service.Domain.Employees;
using Jalasoft.Interns.Service.RepositoryInterfaces;

namespace Jalasoft.Interns.Service.Employees
{
    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {
        public IEnumerable<Employee> RetrieveEmployees(bool active)
        {
            return employeeRepository.RetrieveEmployees(active);
        }
    }
}

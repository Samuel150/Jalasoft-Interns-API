using Jalasoft.Interns.Service.Domain.Employees;
using Jalasoft.Interns.Service.RepositoryInterfaces;

namespace Jalasoft.Interns.Service.Employees
{
    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {
        public Employee CreateEmployee(Employee employee)
        {
            /////Validationes
            
            return employeeRepository.CreateEmployee(employee);

        }

        public IEnumerable<Employee> RetrieveEmployees(bool active)
        {
            return employeeRepository.RetrieveEmployees(active);
        }
    }
}

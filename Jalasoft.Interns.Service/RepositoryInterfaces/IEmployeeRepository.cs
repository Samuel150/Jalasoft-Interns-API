using Jalasoft.Interns.Service.Domain.Employees;

namespace Jalasoft.Interns.Service.RepositoryInterfaces
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> RetrieveEmployees(bool active);

        public Employee CreateEmployee(Employee employee);
    }
}

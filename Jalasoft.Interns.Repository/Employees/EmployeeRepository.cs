using Jalasoft.Interns.Service.Domain.Employees;
using Jalasoft.Interns.Service.RepositoryInterfaces;

namespace Jalasoft.Interns.Repository.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> Employees = new List<Employee>() { 
            new Employee() { Active = true, Email = "samuel@gmail.com", FirstName="Pablo", Id = 1, LastName = "Paramo", Name = "Samuel"},
            new Employee() { Active = true, Email = "ana@gmail.com", FirstName="Eunice", Id = 2, LastName = "Rivero", Name = "Ana"},
            new Employee() { Active = false, Email = "pedro@gmail.com", FirstName="Pedro", Id = 3, LastName = "Torrez", Name = "Gonzalo"}
        };

        public Employee CreateEmployee(Employee employee)
        {
            employee.Id = 4;
            Employees.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> RetrieveEmployees(bool active)
        {
            
            return Employees.Where(employee => employee.Active == active);
        }
    }
}

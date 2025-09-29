using Jalasoft.Interns.API.Requests.Employees;
using Jalasoft.Interns.API.Responses.Employees;
using Jalasoft.Interns.Service.Domain.Employees;

namespace Jalasoft.Interns.API.Adapter
{
    public interface IEmployeeAdapter
    {
        public Employee PostEmployeeRequestToEmployee(PostEmpoyeeRequest request);

        public PostEmployeeResponse EmployeeToPostEmployeeResponse(Employee employee);

        public Employee PatchEmployeeToEmployee(PatchEmployee patchEmployee);
    }

    public class EmployeeAdapter : IEmployeeAdapter
    {
        public Employee PostEmployeeRequestToEmployee(PostEmpoyeeRequest request)
        {
            return new Employee()
            {
                Active = request.Active,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Name = request.Name
            };
        }

        public PostEmployeeResponse EmployeeToPostEmployeeResponse(Employee employee)
        {
            return new PostEmployeeResponse()
            {
                Id = employee.Id,
                Active = employee.Active,
                Email = employee.Email,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Name = employee.Name
            };
        }

        public Employee PatchEmployeeToEmployee(PatchEmployee patchEmployee)
        {
            return new Employee()
            {
                Active = patchEmployee.Active,
                Email = patchEmployee.Email,
                FirstName = patchEmployee.FirstName,
                LastName = patchEmployee.LastName,
                Name = patchEmployee.Name
            };
        }
    }
}

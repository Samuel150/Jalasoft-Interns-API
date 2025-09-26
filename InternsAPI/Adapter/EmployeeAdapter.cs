using Jalasoft.Interns.API.Requests.Employees;
using Jalasoft.Interns.API.Responses;
using Jalasoft.Interns.Service.Domain.Employees;

namespace Jalasoft.Interns.API.Adapter
{
    public static class EmployeeAdapter
    {
        public static Employee PostEmployeeRequestToEmployee(PostEmpoyeeRequest request)
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

        public static PostEmployeeResponse EmployeeToPostEmployeeResponse(Employee employee)
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
    }
}

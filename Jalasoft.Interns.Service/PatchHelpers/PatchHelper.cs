using Jalasoft.Interns.Service.Domain.Employees;

namespace Jalasoft.Interns.Service.PatchHelpers
{
    public static class PatchHelper
    {
        public static PatchEmployee EmployeeToPatchEmployee(Employee employee)
        {
            return new PatchEmployee()
            {
                Active = employee.Active,
                Email = employee.Email,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Name = employee.Name
            };
        }

        public static Employee EmployeePatchToEmployee(PatchEmployee employeePatch, int Id)
        {
            return new Employee()
            {
                Name = employeePatch.Name,
                FirstName = employeePatch.FirstName,
                LastName = employeePatch.LastName,
                Active = employeePatch.Active,
                Email = employeePatch.Email,
                Id = Id
            };
        }
    }
}

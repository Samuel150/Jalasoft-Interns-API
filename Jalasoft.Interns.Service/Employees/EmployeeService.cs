using FluentValidation;
using Jalasoft.Interns.Service.Domain.Employees;
using Jalasoft.Interns.Service.PatchHelpers;
using Jalasoft.Interns.Service.RepositoryInterfaces;
using Jalasoft.Interns.Service.Validators.Employees;
using Microsoft.AspNetCore.JsonPatch;

namespace Jalasoft.Interns.Service.Employees
{
    public class EmployeeService(IEmployeeRepository employeeRepository, EmployeeValidator validator) : IEmployeeService
    {
        public Employee CreateEmployee(Employee employee)
        {

            validator.ValidateAndThrow(employee);

            return employeeRepository.CreateEmployee(employee);

        }

        public Employee PatchEmployee(JsonPatchDocument<PatchEmployee> patchDocument, int id)
        {
            Employee? employeeOld = employeeRepository.RetrieveEmployee(id);
            if(employeeOld is null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                PatchEmployee patchEmployeeOld = PatchHelper.EmployeeToPatchEmployee(employeeOld);
                patchDocument.ApplyTo(patchEmployeeOld);
                return PatchHelper.EmployeePatchToEmployee(patchEmployeeOld, id);
            }
        }

        public IEnumerable<Employee> RetrieveEmployees(bool active)
        {
            return employeeRepository.RetrieveEmployees(active);
        }
    }
}

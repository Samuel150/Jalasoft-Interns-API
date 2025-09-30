using AutoMapper;
using FluentValidation;
using Jalasoft.Interns.Service.Domain.Employees;
using Jalasoft.Interns.Service.Exceptions;
using Jalasoft.Interns.Service.RepositoryInterfaces;
using Jalasoft.Interns.Service.Validators.Employees;
using Microsoft.AspNetCore.JsonPatch;

namespace Jalasoft.Interns.Service.Employees
{
    public class EmployeeService(
        IEmployeeRepository employeeRepository,
        EmployeeValidator validator,
        IMapper mapper) : IEmployeeService
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
                PatchEmployee patchEmployeeOld = mapper.Map<PatchEmployee>(employeeOld);
                patchDocument.ApplyTo(patchEmployeeOld);
                var employee = mapper.Map<Employee>(patchEmployeeOld);
                employee.Id = id;
                return employee;
            }
        }

        public Employee RetrieveEmployee(int id)
        {
            Employee? employeeOld = employeeRepository.RetrieveEmployee(id);
            if (employeeOld is null)
            {
                throw new EmployeeNotFoundException(id);
            }
            return employeeOld;
        }

        public IEnumerable<Employee> RetrieveEmployees(bool active)
        {
            return employeeRepository.RetrieveEmployees(active);
        }
    }
}

using FluentValidation;
using Jalasoft.Interns.Service.Domain.Employees;

namespace Jalasoft.Interns.Service.Validators.Employees
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator() 
        {
            RuleFor(x => x.Name)
                .Length(2, 16);

            RuleFor(x => x.Email)
                .Custom((employee, contexto) =>
                {
                    
                });
        }
    }
}

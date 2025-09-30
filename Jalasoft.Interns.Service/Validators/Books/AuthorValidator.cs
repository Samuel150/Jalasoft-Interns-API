using FluentValidation;
using Jalasoft.Interns.Service.Domain.Books;

namespace Jalasoft.Interns.Service.Validators.Books
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator() 
        {
            RuleFor(a => a.Name).NotEmpty()
                .WithMessage("The author name cannot be empty.");

            RuleFor(a => a.Name).Length(2,35)
                .WithMessage("The author name must be between 2 and 35 characters.");

            RuleFor(a => a.Age).NotEmpty()
                .WithMessage("The author age cannot be empty.");

            RuleFor(a => a.Age).GreaterThan(0)
                .WithMessage("The author age must be grater than 0.");
        }
    }
}

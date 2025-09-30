using FluentValidation;
using Jalasoft.Interns.Service.Domain.Books;

namespace Jalasoft.Interns.Service.Validators.Books
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator() 
        { 
            RuleFor(b => b.Title).NotEmpty()
                .WithMessage("The title cannot be empty.");
            RuleFor(b => b.Title).Length(3, 100)
                .WithMessage("The title must be between 3 and 100 characters.");

            RuleFor(b => b.Genre).NotEmpty()
                .WithMessage("The genre cannot be empty.");
            RuleFor(b => b.Genre).Length(3, 50)
                .WithMessage("The genre must be between 3 and 50 characters.");

            RuleFor(b => b.PublishDate)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
                .WithMessage("The publication date cannot be greater than the current date.");

            RuleForEach(b => b.Authors).NotEmpty()
                .WithMessage("The author cannot be empty.");
            RuleForEach(b => b.Authors).SetValidator(new AuthorValidator());
        }
    }
}

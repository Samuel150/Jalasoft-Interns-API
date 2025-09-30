using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Jalasoft.Interns.API.ExceptionHandling.Handlers
{
    public class ValidationExceptionHandler : ErrorHandler
    {
        public override void Handle(ErrorHandlerContext context)
        {
            if (context.Exception is ValidationException ex)
            {
                context.Handled = true;

                var errorMessages = ex.Errors
                    .Select(e => e.ErrorMessage)
                    .Distinct()
                    .ToList();

                context.Result = new BadRequestObjectResult(new HttpErrorResponseValidations
                {
                    Message = "Request is not valid. See errors for more details.",
                    Errors = errorMessages
                });
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Jalasoft.Interns.API.ExceptionHandling
{
    public abstract class ErrorHandler : IErrorHandler
    {
        public abstract void Handle(ErrorHandlerContext context);

        public IActionResult NotFound(string message)
        {
            return new NotFoundObjectResult(new HttpErrorResponse
            {
                Message = message
            });
        }

        public IActionResult BadRequest(string message)
        {
            return new BadRequestObjectResult(new HttpErrorResponse
            {
                Message = "Request is not valid. See errors for more details",
            });
        }

        ///Http Errors
    }
}

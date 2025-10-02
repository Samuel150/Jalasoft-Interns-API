using Jalasoft.Interns.Service.Exceptions;

namespace Jalasoft.Interns.API.ExceptionHandling.Handlers
{
    public class CityNotFoundExceptionHandler : ErrorHandler
    {
        public override void Handle(ErrorHandlerContext context)
        {
            if (context.Exception is CityNotFoundException ex)
            {   
                context.Handled = true;
                context.Result = NotFound(ex.Message);
            }
        }
    }
}

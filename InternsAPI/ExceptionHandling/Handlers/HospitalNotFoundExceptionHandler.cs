using Jalasoft.Interns.Service.Exceptions;

namespace Jalasoft.Interns.API.ExceptionHandling.Handlers
{
    public class HospitalNotFoundExceptionHandler : ErrorHandler
    {
        public override void Handle(ErrorHandlerContext context)
        {
            if (context.Exception is HospitalNotFoundException ex)
            {
                context.Handled = true;
                context.Result = NotFound(ex.Message);
            }
        }
    }
}

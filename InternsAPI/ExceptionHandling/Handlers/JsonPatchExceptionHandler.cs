using Microsoft.AspNetCore.JsonPatch.Exceptions;

namespace Jalasoft.Interns.API.ExceptionHandling.Handlers
{
    public class JsonPatchExceptionHandler : ErrorHandler
    {
        public override void Handle(ErrorHandlerContext context)
        {
            if (context.Exception is JsonPatchException ex)
            {
                context.Handled = true;
                context.Result = BadRequestJsonPatch(ex.Message);
            }
        }
    }
}

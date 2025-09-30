using Microsoft.AspNetCore.Mvc;

namespace Jalasoft.Interns.API.ExceptionHandling
{
    public class ResponseFilter
    {
        public IEnumerable<IErrorHandler> Handlers { get; }

        public ResponseFilter(IEnumerable<IErrorHandler> handlers)
        {
            Handlers = handlers;
        }

        public IActionResult Excecute(Func<IActionResult> action)
        {
            try
            {
                return action.Invoke();
            }
            catch (Exception ex)
            {
                ErrorHandlerContext errorHandlerContext = new ErrorHandlerContext(ex);
                foreach (IErrorHandler handler in Handlers)
                {
                    handler.Handle(errorHandlerContext);
                    if (errorHandlerContext.Handled)
                    {
                        break;
                    }
                }

                if (errorHandlerContext.Result == null)
                {
                    ObjectResult objectResult = new ObjectResult(new HttpErrorResponse
                    {
                        Message = "Oops, something went wrong."
                    });
                    objectResult.StatusCode = 500;
                    errorHandlerContext.Result = objectResult;
                }

                return errorHandlerContext.Result;
            }
        }
    }
}

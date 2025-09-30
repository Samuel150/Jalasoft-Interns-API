using Microsoft.AspNetCore.Mvc;

namespace Jalasoft.Interns.API.ExceptionHandling
{
    public class ErrorHandlerContext
    {
        public Exception Exception { get; }

        public IActionResult Result { get; set; }

        public bool Handled { get; set; }

        public ErrorHandlerContext(Exception ex)
        {
            this.Exception = ex;
        }
    }
}

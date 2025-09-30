namespace Jalasoft.Interns.API.ExceptionHandling
{
    public interface IErrorHandler
    {
        void Handle(ErrorHandlerContext context);
    }
}

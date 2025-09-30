namespace Jalasoft.Interns.Service.Exceptions
{
    public class InternsException : Exception
    {
        public string Message { get; }
        public InternsException(string message) : base(message) 
        {
            Message = message;
        }
    }
}

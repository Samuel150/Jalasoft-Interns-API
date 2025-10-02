namespace Jalasoft.Interns.Service.Exceptions
{
    public class BookNotFoundException : InternsException
    {
        public BookNotFoundException(int bookId)
            : base($"Book with id: {bookId}, not found")
        {
        }
    }
}
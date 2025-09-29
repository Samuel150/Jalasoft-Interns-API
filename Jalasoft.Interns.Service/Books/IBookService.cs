using Jalasoft.Interns.Service.Domain.Books;

namespace Jalasoft.Interns.Service.Books
{
    public interface IBookService
    {
        public IEnumerable<Book> RetrieveBooks(bool active);
        public IEnumerable<Book> RetrieveBooksByAuthor(string author);

        public Book CreateBook(Book book);
        public Book UpdateBook(Book book);
    }
}

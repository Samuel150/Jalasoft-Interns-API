using Jalasoft.Interns.Service.Domain.Books;

namespace Jalasoft.Interns.Service.RepositoryInterfaces
{
    public interface IBookRepository
    {
        public IEnumerable<Book> RetrieveBooks(bool active);
        public IEnumerable<Book> RetrieveBooksByAuthor(string author);

        public Book CreateBook(Book book);
        public Book UpdateBook(Book book);
        public Book? RetrieveBook(int bookId);
    }
}

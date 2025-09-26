using Jalasoft.Interns.Service.Domain.Books;
using Jalasoft.Interns.Service.RepositoryInterfaces;

namespace Jalasoft.Interns.Service.Books
{
    public class BookService(IBookRepository bookRepository) : IBookService
    {
        public Book CreateBook(Book book)
        {
            return bookRepository.CreateBook(book);
        }

        public IEnumerable<Book> RetrieveBooks(bool active)
        {
            return bookRepository.RetrieveBooks(active);
        }

        public IEnumerable<Book> RetrieveBooksByAuthor(string author)
        {
            return bookRepository.RetrieveBooksByAuthor(author);
        }

        public Book UpdateBook(Book book)
        {
            return bookRepository.UpdateBook(book);
        }
    }
}

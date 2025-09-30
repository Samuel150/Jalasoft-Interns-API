using Jalasoft.Interns.Service.Domain.Books;
using Jalasoft.Interns.Service.PatchHelpers;
using Jalasoft.Interns.Service.RepositoryInterfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace Jalasoft.Interns.Service.Books
{
    public class BookService(IBookRepository bookRepository) : IBookService
    {
        public Book CreateBook(Book book)
        {
            return bookRepository.CreateBook(book);
        }

        public Book PatchBook(JsonPatchDocument<PatchBook> patchDocument, int id)
        {
            Book? oldBook = bookRepository.RetrieveBook(id);
            if (oldBook is null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                PatchBook patchOldBook = PatchHelperBook.BookToPatchBook(oldBook);
                patchDocument.ApplyTo(patchOldBook);
                return PatchHelperBook.BookPatchToBook(patchOldBook, id);
            }
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

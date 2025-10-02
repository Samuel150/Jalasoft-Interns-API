using FluentValidation;
using Jalasoft.Interns.Service.Domain.Books;
using Jalasoft.Interns.Service.Exceptions;
using Jalasoft.Interns.Service.PatchHelpers;
using Jalasoft.Interns.Service.RepositoryInterfaces;
using Jalasoft.Interns.Service.Validators.Books;
using Microsoft.AspNetCore.JsonPatch;

namespace Jalasoft.Interns.Service.Books
{
    public class BookService(IBookRepository bookRepository, BookValidator validator) : IBookService
    {
        public Book CreateBook(Book book)
        {
            validator.ValidateAndThrow(book);
            return bookRepository.CreateBook(book);
        }

        public Book PatchBook(JsonPatchDocument<PatchBook> patchDocument, int id)
        {
            Book? oldBook = bookRepository.RetrieveBook(id);
            if (oldBook is null)
            {
                throw new BookNotFoundException(id);
            }
            else
            {
                validator.ValidateAndThrow(oldBook);
                PatchBook patchOldBook = PatchHelperBook.BookToPatchBook(oldBook);
                patchDocument.ApplyTo(patchOldBook);
                return PatchHelperBook.BookPatchToBook(patchOldBook, id);
            }
        }

        public Book RetrieveBookById(int id)
        {
            Book? book = bookRepository.RetrieveBook(id);
            if (book is null)
            {
                throw new BookNotFoundException(id);
            }
            return book;
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
            var existingBook = RetrieveBookById(book.Id);
            if (existingBook == null)
            {
                throw new BookNotFoundException(book.Id);
            }
            validator!.ValidateAndThrow(book);
            return bookRepository.UpdateBook(book);
        }
    }
}

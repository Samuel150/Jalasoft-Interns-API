using Jalasoft.Interns.Service.Domain.Books;
using Microsoft.AspNetCore.JsonPatch;

namespace Jalasoft.Interns.Service.Books
{
    public interface IBookService
    {
        public IEnumerable<Book> RetrieveBooks(bool active);
        public IEnumerable<Book> RetrieveBooksByAuthor(string author);

        public Book CreateBook(Book book);
        public Book UpdateBook(Book book);
        public Book RetrieveBookById(int id);
        public Book PatchBook(JsonPatchDocument<PatchBook> patchDocument, int id);
    }
}

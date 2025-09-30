using Jalasoft.Interns.API.Requests.Books;
using Jalasoft.Interns.API.Responses.Books;
using Jalasoft.Interns.Service.Domain.Books;

namespace Jalasoft.Interns.API.Adapters
{
    public interface IBookAdapter
    {
        public Book PostBookRequestToBook(PostBookRequest request);
        public PostBookResponse BookToPostBookResponse(Book book);
        public Book PutBookRequestToBook(PutBookRequest request);
        public PutBookResponse BookToPutBookResponse(Book updatedBook);
        public Book PatchBookToBook(PatchBook patchBook);
    }
    public class BookAdapter : IBookAdapter
    {
        public Book PostBookRequestToBook(PostBookRequest request)
        {
            return new Book()
            {
                Active = request.Active,
                Title = request.Title,
                Authors = request.Authors,
                PublishDate = request.PublishDate,
                Genre = request.Genre,
            };
        }

        public PostBookResponse BookToPostBookResponse(Book book)
        {
            return new PostBookResponse()
            {
                Id = book.Id,
                Title = book.Title,
                Authors = book.Authors,
                PublishDate = book.PublishDate,
                Genre = book.Genre,
                Active = book.Active,
            };
        }

        public Book PutBookRequestToBook(PutBookRequest request)
        {
            return new Book()
            {
                Active = request.Active,
                Title = request.Title,
                Authors = request.Authors,
                PublishDate = request.PublishDate,
                Genre = request.Genre,
            };
        }

        public PutBookResponse BookToPutBookResponse(Book updatedBook)
        {
            return new PutBookResponse()
            {
                Id = updatedBook.Id,
                Title = updatedBook.Title,
                Authors = updatedBook.Authors,
                PublishDate = updatedBook.PublishDate,
                Genre = updatedBook.Genre,
                Active = updatedBook.Active,
            };
        }

        public Book PatchBookToBook(PatchBook patchBook)
        {
            return new Book()
            {
                Title = patchBook.Title,
                Genre = patchBook.Genre,
                PublishDate= patchBook.PublishDate,
                Authors = patchBook.Authors,
                Active = patchBook.Active,
            };
        }
    }
}

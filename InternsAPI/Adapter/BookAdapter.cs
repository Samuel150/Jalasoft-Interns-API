using Jalasoft.Interns.API.Requests.Books;
using Jalasoft.Interns.API.Responses.Books;
using Jalasoft.Interns.Service.Domain.Books;

namespace Jalasoft.Interns.API.Adapter
{
    public class BookAdapter
    {
        public static Book PostBookRequestToBook(PostBookRequest request)
        {
            return new Book()
            {
                Active = request.Active,
                Title = request.Title,
                Author = request.Author,
                PublishDate = request.PublishDate,
                Genre = request.Genre,
            };
        }

        public static PostBookResponse BookToPostBookResponse(Book book)
        {
            return new PostBookResponse()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublishDate = book.PublishDate,
                Genre = book.Genre,
                Active = book.Active,
            };
        }
    }
}

using Jalasoft.Interns.API.Requests.Books;
using Jalasoft.Interns.API.Responses.Books;
using Jalasoft.Interns.Service.Domain.Books;
using System;

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

        public static Book PutBookRequestToBook(PutBookRequest request)
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

        internal static object? BookToPutBookResponse(Book updatedBook)
        {
            return new PutBookResponse()
            {
                Id = updatedBook.Id,
                Title = updatedBook.Title,
                Author = updatedBook.Author,
                PublishDate = updatedBook.PublishDate,
                Genre = updatedBook.Genre,
                Active = updatedBook.Active,
            };
        }
    }
}

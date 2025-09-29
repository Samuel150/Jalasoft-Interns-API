using Jalasoft.Interns.API.Adapter;
using Jalasoft.Interns.API.Requests.Books;
using Jalasoft.Interns.Service.Books;
using Microsoft.AspNetCore.Mvc;

namespace InternsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController(ILogger<BooksController> logger, IBookService bookService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBooks([FromQuery] bool active)
        {
            logger.Log(LogLevel.Information, "Retrieving Books");
            var employees = bookService.RetrieveBooks(active);
            return Ok(employees);
        }

        [HttpGet("authors")]
        public IActionResult GetBooksByAuthor([FromQuery] string author)
        {
            logger.Log(LogLevel.Information, "Retrieving Books by Author");
            var employees = bookService.RetrieveBooksByAuthor(author);
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] PostBookRequest request)
        {
            logger.Log(LogLevel.Information, "Create Book");
            var bookCreated = bookService.CreateBook(BookAdapter.PostBookRequestToBook(request));
            return Created("", BookAdapter.BookToPostBookResponse(bookCreated));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] PutBookRequest request)
        {
            logger.Log(LogLevel.Information, $"Updating Book with ID {id}");

            var bookToUpdate = BookAdapter.PutBookRequestToBook(request);
            bookToUpdate.Id = id;

            var updatedBook = bookService.UpdateBook(bookToUpdate);
            return Ok(BookAdapter.BookToPutBookResponse(updatedBook));
        }
    }
}

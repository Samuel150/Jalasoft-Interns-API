using Jalasoft.Interns.API.Adapters;
using Jalasoft.Interns.API.ExceptionHandling;
using Jalasoft.Interns.API.Requests.Books;
using Jalasoft.Interns.Service.Books;
using Jalasoft.Interns.Service.Domain.Books;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace InternsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController(
        ILogger<BooksController> logger, 
        IBookService bookService,
        IBookAdapter bookAdapter,
        ResponseFilter filter ) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBooks([FromQuery] bool active)
        {
            return filter.Excecute(() =>
            {
                logger.Log(LogLevel.Information, "Retrieving Books");
                var employees = bookService.RetrieveBooks(active);
                return Ok(employees);
            });
            
        }

        [HttpGet("authors")]
        public IActionResult GetBooksByAuthor([FromQuery] string author)
        {
            return filter.Excecute(() =>
            {
                logger.Log(LogLevel.Information, "Retrieving Books by Author");
                var employees = bookService.RetrieveBooksByAuthor(author);
                return Ok(employees);
            });
            
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] PostBookRequest request)
        {
            return filter.Excecute(() =>
            {
                logger.Log(LogLevel.Information, "Create Book");
                var bookCreated = bookService.CreateBook(bookAdapter.PostBookRequestToBook(request));
                return Created("", bookAdapter.BookToPostBookResponse(bookCreated));
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] PutBookRequest request)
        {
            return filter.Excecute(() =>
            {
                logger.Log(LogLevel.Information, $"Updating Book with ID {id}");

                var bookToUpdate = bookAdapter.PutBookRequestToBook(request);
                bookToUpdate.Id = id;

                var updatedBook = bookService.UpdateBook(bookToUpdate);
                return Ok(bookAdapter.BookToPutBookResponse(updatedBook));
            });
        }
        [HttpPatch]
        [Route("{id}")]
        public IActionResult PatchBoook(
            [FromBody] JsonPatchDocument<PatchBook> patchDocument,
            int id)
        {
            return filter.Excecute(() =>
            {
                logger.Log(LogLevel.Information, "Patch Book");
                var bookCreated = bookService.PatchBook(patchDocument, id);
                return Ok(bookAdapter.BookToPostBookResponse(bookCreated));
            });
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBook(int id)
        {
            return filter.Excecute(() =>
            {
                logger.Log(LogLevel.Information, "Retrieving Book");
                var book = bookService.RetrieveBookById(id);
                return Ok(book);
            });
        }
    }
}

using AutoMapper;
using Jalasoft.Interns.API.ExceptionHandling;
using Jalasoft.Interns.API.Requests.Books;
using Jalasoft.Interns.API.Responses.Books;
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
        IMapper mapper,
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
                var bookCreated = bookService.CreateBook(mapper.Map<Book>(request));
                return Created("", mapper.Map<PostBookResponse>(bookCreated));
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] PutBookRequest request)
        {
            return filter.Excecute(() =>
            {
                logger.Log(LogLevel.Information, $"Updating Book with ID {id}");

                var bookToUpdate = mapper.Map<Book>(request);
                bookToUpdate.Id = id;

                var updatedBook = bookService.UpdateBook(bookToUpdate);
                return Ok(mapper.Map<PutBookResponse>(updatedBook));
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
                return Ok(mapper.Map<PostBookResponse>(bookCreated));
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

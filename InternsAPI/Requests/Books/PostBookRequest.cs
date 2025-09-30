using Jalasoft.Interns.Service.Domain.Books;

namespace Jalasoft.Interns.API.Requests.Books
{
    public class PostBookRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateOnly PublishDate { get; set; }
        public List<Author>? Authors { get; set; }
        public bool Active { get; set; }
    }
}

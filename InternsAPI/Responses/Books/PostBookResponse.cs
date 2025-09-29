namespace Jalasoft.Interns.API.Responses.Books
{
    public class PostBookResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateOnly PublishDate { get; set; }
        public bool Active { get; set; }
    }
}

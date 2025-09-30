using Jalasoft.Interns.Service.Domain.Books;

namespace Jalasoft.Interns.Service.PatchHelpers
{
    public static class PatchHelperBook
    {
        public static PatchBook BookToPatchBook(Book book)
        {
            return new PatchBook()
            {
                Title = book.Title,
                Genre = book.Genre,
                PublishDate = book.PublishDate,
                Active = book.Active,
                Authors = book.Authors?.Select(a => new Author
                {
                    Name = a.Name,
                    Age = a.Age
                }).ToList() ?? new List<Author>()
            };
        }

        public static Book BookPatchToBook(PatchBook patchBook, int id)
        {
            return new Book()
            {
                Id = id,
                Title = patchBook.Title,
                Genre = patchBook.Genre,
                PublishDate = patchBook.PublishDate,
                Active = patchBook.Active,
                Authors = patchBook.Authors?.Select(a => new Author
                {
                    Name = a.Name,
                    Age = a.Age
                }).ToList() ?? new List<Author>()
            };
        }
    }
}

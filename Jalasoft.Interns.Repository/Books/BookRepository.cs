using Jalasoft.Interns.Service.Domain.Books;
using Jalasoft.Interns.Service.RepositoryInterfaces;
using System;

namespace Jalasoft.Interns.Repository.Books
{
    public class BookRepository : IBookRepository
    {
        private List<Book> _books = new List<Book> {
            new Book { Id = 1, Title = "Cien años de soledad", Authors = new List<Author> { new Author { Name = "Gabriel García Márquez", Age = 87 } },
                Genre = "Realismo mágico", PublishDate = new DateOnly(1967, 5, 30), Active = true },
            new Book { Id = 2, Title = "1984", Authors = new List<Author> { new Author { Name = "George Orwell", Age = 46 } },
                Genre = "Distopía", PublishDate = new DateOnly(1949, 6, 8), Active = false },
            new Book { Id = 3, Title = "Orgullo y prejuicio", Authors = new List<Author> { new Author { Name = "Jane Austen", Age = 41 } },
                Genre = "Romance", PublishDate = new DateOnly(1813, 1, 28), Active = true },
            new Book { Id = 4, Title = "El nombre del viento", Authors = new List<Author> { new Author { Name = "Patrick Rothfuss", Age = 50 } },
                Genre = "Fantasía", PublishDate = new DateOnly(2007, 3, 27), Active = false },
            new Book { Id = 5, Title = "Sapiens", Authors = new List<Author> { new Author { Name = "Yuval Noah Harari", Age = 48 } },
                Genre = "Historia", PublishDate = new DateOnly(2011, 1, 1), Active = true }
    };

        private int _nextId = 6; 

        public Book CreateBook(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }

        public Book? RetrieveBook(int bookId)
        {
            return _books.FirstOrDefault(book => book.Id == bookId);
        }

        public IEnumerable<Book> RetrieveBooks(bool active)
        {
            return _books.Where(book => book.Active == active);
        }

        public IEnumerable<Book> RetrieveBooksByAuthor(string authorName)
        {
            return _books.Where(book => book.Authors != null && book.Authors.Any(a => a.Name == authorName));
        }

        public Book UpdateBook(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook == null)
            {
                throw new KeyNotFoundException($"No se encontró el libro con ID {book.Id}");
            }

            existingBook.Title = book.Title;
            existingBook.Authors = book.Authors;
            existingBook.Genre = book.Genre;
            existingBook.PublishDate = book.PublishDate;
            existingBook.Active = book.Active;

            return existingBook;
        }
    }
}

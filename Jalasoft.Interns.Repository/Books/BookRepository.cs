using Jalasoft.Interns.Service.Domain.Books;
using Jalasoft.Interns.Service.RepositoryInterfaces;
using System;

namespace Jalasoft.Interns.Repository.Books
{
    public class BookRepository : IBookRepository
    {
        private List<Book> _books = new List<Book> { 
            new Book { Id = 1, Title = "Cien años de soledad", Author = "Gabriel García Márquez", Genre = "Realismo mágico", PublishDate = new DateOnly(1967, 5, 30), Active = true }, 
            new Book { Id = 2, Title = "1984", Author = "George Orwell", Genre = "Distopía", PublishDate = new DateOnly(1949, 6, 8), Active = false }, 
            new Book { Id = 3, Title = "Orgullo y prejuicio", Author = "Jane Austen", Genre = "Romance", PublishDate = new DateOnly(1813, 1, 28), Active = true }, 
            new Book { Id = 4, Title = "El nombre del viento", Author = "Patrick Rothfuss", Genre = "Fantasía", PublishDate = new DateOnly(2007, 3, 27), Active = false }, 
            new Book { Id = 5, Title = "Sapiens", Author = "Yuval Noah Harari", Genre = "Historia", PublishDate = new DateOnly(2011, 1, 1), Active = true } 
        };

        private int _nextId = 6; 

        public Book CreateBook(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }

        public IEnumerable<Book> RetrieveBooks(bool active)
        {
            return _books.Where(book => book.Active == active);
        }

        public IEnumerable<Book> RetrieveBooksByAuthor(string author)
        {
            return _books.Where(book => book.Author == author);
        }

        public Book UpdateBook(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook == null)
            {
                throw new KeyNotFoundException($"No se encontró el libro con ID {book.Id}");
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Genre = book.Genre;
            existingBook.PublishDate = book.PublishDate;
            existingBook.Active = book.Active;

            return existingBook;
        }
    }
}

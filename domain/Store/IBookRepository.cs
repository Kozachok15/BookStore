using Store.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public interface IBookRepository
    {
        Task<BookEF[]> GetAllBooks();
        Task<BookEF[]> GetAllBooksByIds(IEnumerable <int> bookIds);
        Task<BookEF> GetBookById(int id);
        Task<BookEF[]> GetAllBooksByIsbn(string isbn);
        Task<BookEF[]> GetAllBooksByTitleOrAuthor(string titleOrAuthor);
        Task UpdateBookById(int id, string Description, string Title, string Genre, decimal Price);
        void AddBook(int AuthorID, int PublisherID, string? Genre, string Title, string Isbn, string? Description, decimal Price);
        Task DeleteBookById(int id);
        void AddAuthor(string FullName);
        Task<AuthorEF> GetAuthorById(int id);
        Task<PublisherEF> GetPublisher();
        Task<AuthorEF[]> GetAllAuthors();
        Task<AuthorEF> GetAuthorByName(string namePart);

    }
}

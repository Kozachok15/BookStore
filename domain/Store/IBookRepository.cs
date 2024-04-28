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
        void UpdateBookById(int id, string Description, string Title, string Genre, decimal Price);
        void AddBook(AuthorEF Author, PublisherEF Publisher, string? Genre, string Title, string Isbn, string? Description, decimal Price);
        void DeleteBookById(int id);
        void AddAuthor(string FullName);
        Task<AuthorEF> GetAuthorById(int id);
        Task<PublisherEF> GetPublisherById(int id);
        Task<AuthorEF[]> GetAllAuthors();
        Task<AuthorEF> GetAuthorByName(string namePart);

    }
}

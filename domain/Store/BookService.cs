using Store.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Store
{
    public class BookService
    {
        private readonly IBookRepository booksRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.booksRepository = bookRepository;
        }

        public async Task<BookEF[]> GettAllByQuery(string query)
        {            
            if (Book.IsIsbn(query))
                return await booksRepository.GetAllBooksByIsbn(query);

            return await booksRepository.GetAllBooksByTitleOrAuthor(query);
        }

        public async Task<BookEF[]> GettAllBooks()
        {
            return await booksRepository.GetAllBooks();
        }

        public async Task<BookEF> GettBookByID(int id)
        {
            return await booksRepository.GetBookById(id);
        }

        public async Task DeleteBook(int id)
        {
            await booksRepository.DeleteBookById(id);
        }

        public async Task AddBook(string? Genre, string Title, string Isbn, string? Description, decimal Price, string AuthorFullName)
        {
            PublisherEF publisher = await booksRepository.GetPublisherById(1);
            booksRepository.AddAuthor(AuthorFullName);
            AuthorEF author = await booksRepository.GetAuthorByName(AuthorFullName);
            booksRepository.AddBook(author, publisher, Genre, Title, Isbn, Description, Price);
        }

        public async Task UpdateBook(int id, string Description, string Title, string Genre, decimal Price)
        {
            await booksRepository.UpdateBookById(id, Description, Title, Genre, Price);
        }

        public async Task<AuthorEF[]> GetAllAuthors()
        {
            return await booksRepository.GetAllAuthors();
        }

    }
}

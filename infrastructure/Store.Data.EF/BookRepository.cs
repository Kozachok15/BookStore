using Microsoft.EntityFrameworkCore;
using Store.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.EF
{
    public class BookRepository : IBookRepository
    {
        public async Task<BookEF[]> GetAllBooks()
        {
            using(var context = new StoreContext())
            {
                return await context.Books.Include(book => book.Publisher).Include(book => book.Author).ToArrayAsync();
            }
        }

        public async Task<BookEF[]> GetAllBooksByIds(IEnumerable<int> bookIds)
        {
            using (var context = new StoreContext())
            {
                return await context.Books.Include(book => book.Publisher).Include(book => book.Author)
                                    .Where(book => bookIds.Contains(book.Id)).ToArrayAsync();
            }
        }

        public async Task<BookEF[]> GetAllBooksByIsbn(string isbn)
        {
            using(var context = new StoreContext())
            {
                return await context.Books.Include(book => book.Publisher).Include(book => book.Author)
                                    .Where(book => book.IsbnOf == isbn).ToArrayAsync();
            }
        }

        public async Task<BookEF[]> GetAllBooksByTitleOrAuthor(string titleOrAuthor)
        {
            using (var context = new StoreContext())
            {
                return await context.Books.Include(book => book.Publisher).Include(book => book.Author)
                                    .Where(book => book.Author.FullName.Contains(titleOrAuthor) || book.TitleOf.Contains(titleOrAuthor)).ToArrayAsync();

                
            }
        }

        public async Task<BookEF> GetBookById(int id)
        {            
            using(var context = new StoreContext())
            {
                return await context.Books.Where(book => book.Id == id).Include(book => book.Publisher).Include(book => book.Author).SingleAsync();
                
            }
        }

        public async void UpdateBookById(int id, string Description, string Title, string Genre, decimal Price)
        {
            using (var context = new StoreContext())
            {
                var book = await context.Books.Where(book => book.Id == id).Include(book => book.Publisher).Include(book => book.Author).SingleAsync();
                book.DescriptionOf = Description;
                book.TitleOf = Title;
                book.GenreOf = Genre;
                book.PriceOf = Price;
                context.SaveChanges();
            }
        }

        public async void AddBook(AuthorEF Author, PublisherEF Publisher, string? Genre, string Title, string Isbn, string? Description, decimal Price)
        {
            using (var context = new StoreContext())
            {
                BookEF book =  new BookEF()
                {
                    Author = Author,
                    Publisher = Publisher,
                    GenreOf = Genre,
                    TitleOf = Title,
                    IsbnOf = Isbn,
                    DescriptionOf = Description,
                    PriceOf = Price
                };

                await context.Books.AddAsync(book);
                await context.SaveChangesAsync();
            }
        }

        public async void DeleteBookById(int id)
        {
            using (var context = new StoreContext())
            {
                var bookToDelete = await context.Books.Where(book => book.Id == id).SingleAsync();

                if(bookToDelete != null)
                {
                    context.Books.Remove(bookToDelete);
                    await context.SaveChangesAsync();
                }                
            }
        }

        public async void AddAuthor(string FullName)
        {
            using (var context = new StoreContext())
            {
                AuthorEF author = new AuthorEF()
                {
                    FullName = FullName,
                };

                await context.Authors.AddAsync(author);
                await context.SaveChangesAsync();
            }
        }

        public async Task<AuthorEF> GetAuthorById(int id)
        {
            using (var context = new StoreContext())
            {
                return await context.Authors.Where(author => author.Id == id).SingleAsync();
            }
        }

        public async Task<AuthorEF> GetAuthorByName(string namePart)
        {
            using (var context = new StoreContext())
            {
                return await context.Authors.Where(author => author.FullName.Contains(namePart)).SingleAsync();


            }
        }

        public async Task<AuthorEF[]> GetAllAuthors()
        {
            using (var context = new StoreContext())
            {
                return await context.Authors.ToArrayAsync();
            }
        }

        public async Task<PublisherEF> GetPublisherById(int id)
        {
            using (var context = new StoreContext())
            {
                return await context.Publishers.Where(publisher => publisher.Id == id).SingleAsync();
            }
        }

    }
}

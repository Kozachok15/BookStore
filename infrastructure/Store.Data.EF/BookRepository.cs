using Microsoft.EntityFrameworkCore;
using Store.Entities;
using System;
using System.Collections.Generic;
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

        public async Task<BookEF[]> GetAllByIds(IEnumerable<int> bookIds)
        {
            using (var context = new StoreContext())
            {
                return await context.Books.Include(book => book.Publisher).Include(book => book.Author)
                                    .Where(book => bookIds.Contains(book.Id)).ToArrayAsync();
            }
        }

        public async Task<BookEF[]> GetAllByIsbn(string isbn)
        {
            using(var context = new StoreContext())
            {
                return await context.Books.Include(book => book.Publisher).Include(book => book.Author)
                                    .Where(book => book.IsbnOf == isbn).ToArrayAsync();
            }
        }

        public async Task<BookEF[]> GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            using (var context = new StoreContext())
            {
                var books = await context.Books.Include(book => book.Publisher).Include(book => book.Author)
                                    .Where(book => book.Author.FullName.Contains(titleOrAuthor) || book.TitleOf.Contains(titleOrAuthor)).ToArrayAsync();

                return books;
            }
        }

        public async Task<BookEF> GetById(int id)
        {            
            using(var context = new StoreContext())
            {
                var book = await context.Books.Where(book => book.Id == id).Include(book => book.Publisher).Include(book => book.Author).SingleAsync();
                return book;
            }
        }
    }
}

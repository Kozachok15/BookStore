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
        public BookEF[] GetAllBooks()
        {
            using(var context = new StoreContext())
            {
                return context.Books.Include(book => book.Publisher).Include(book => book.Author).ToArray();
            }
        }

        public BookEF[] GetAllByIds(IEnumerable<int> bookIds)
        {
            using (var context = new StoreContext())
            {
                return context.Books.Include(book => book.Publisher).Include(book => book.Author)
                                    .Where(book => bookIds.Contains(book.Id)).ToArray();
            }
        }

        public BookEF[] GetAllByIsbn(string isbn)
        {
            using(var context = new StoreContext())
            {
                return context.Books.Include(book => book.Publisher).Include(book => book.Author)
                                    .Where(book => book.IsbnOf == isbn).ToArray();
            }
        }   

        public BookEF[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            using (var context = new StoreContext())
            {
                var books = context.Books.Include(book => book.Publisher).Include(book => book.Author)
                                    .Where(book => book.Author.FullName.Contains(titleOrAuthor) || book.TitleOf.Contains(titleOrAuthor)).ToArray();

                return books;
            }
        }

        public BookEF GetById(int id)
        {            
            using(var context = new StoreContext())
            {
                var book = context.Books.Where(book => book.Id == id).Include(book => book.Publisher).Include(book => book.Author).Single();
                return book;
            }
        }
    }
}

using Store.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
                return await booksRepository.GetAllByIsbn(query);

            return await booksRepository.GetAllByTitleOrAuthor(query);
        }

        public async Task<BookEF[]> GettAllBooks()
        {
            return await booksRepository.GetAllBooks();
        }

        public async Task<BookEF> GettBookByID(int id)
        {
            return await booksRepository.GetById(id);
        }

    }
}

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

        public BookEF[] GettAllByQuery(string query)
        {
            if (Book.IsIsbn(query))
                return booksRepository.GetAllByIsbn(query);

            return booksRepository.GetAllByTitleOrAuthor(query);
        }

        public BookEF[] GettAllBooks()
        {
            return booksRepository.GetAllBooks();
        }

        public BookEF GettBookByID(int id)
        {
            return booksRepository.GetById(id);
        }

    }
}

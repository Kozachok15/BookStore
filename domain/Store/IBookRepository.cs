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
        Task<BookEF[]> GetAllByIds(IEnumerable <int> bookIds);
        Task<BookEF> GetById(int id);
        Task<BookEF[]> GetAllByIsbn(string isbn);
        Task<BookEF[]> GetAllByTitleOrAuthor(string titleOrAuthor);
    }
}

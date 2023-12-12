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
        BookEF[] GetAllBooks();
        BookEF[] GetAllByIds(IEnumerable <int> bookIds);
        BookEF GetById(int id);
        BookEF[] GetAllByIsbn(string isbn);
        BookEF[] GetAllByTitleOrAuthor(string titleOrAuthor);
    }
}

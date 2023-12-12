using Microsoft.AspNetCore.Mvc;
using Store.Entities;

namespace Store.Web.Controllers
{
    public class BookController : Controller
    {   
        private readonly BookService bookService;

        public BookController(BookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Index(int id)
        {
            BookEF book = bookService.GettBookByID(id);
            return View("Index", book);
        }
    }
}

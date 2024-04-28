using Microsoft.AspNetCore.Mvc;
using Store.Entities;

namespace Store.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly BookService bookService;

        public BookController(BookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> Index(int id)
        {
            BookEF book = await bookService.GettBookByID(id);
            return View("Index", book);
        }

        public async Task<IActionResult> Update(int id)
        {
            BookEF book = await bookService.GettBookByID(id);
            return View("Index", book);
        }
    }
}

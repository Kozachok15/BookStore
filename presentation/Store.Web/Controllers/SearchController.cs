using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly BookService bookService;

        public SearchController(BookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> Index(string query)
        {
            var books = await bookService.GettAllByQuery(query);
            return View(books);
        }
    }
}

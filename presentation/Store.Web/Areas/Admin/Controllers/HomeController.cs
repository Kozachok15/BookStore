using Microsoft.AspNetCore.Mvc;
using Store.Entities;
using Store.Web.Models;
using System.Diagnostics;

namespace Store.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly BookService bookService;

        public HomeController(BookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await bookService.GettAllBooks();
            return View(books);
        }

        public IActionResult AddBook()
        {
            return View("BookAdd");
        }

        public async Task Add(string? Genre, string Title, string Isbn, string? Description, string Price, string AuthorFullName)
        {
            await bookService.AddBook(Genre,Title,Isbn,Description,Convert.ToDecimal(Price),AuthorFullName);
        }

        public async Task DeleteBook(int id)
        {
            await bookService.DeleteBook(id);
        }

        public async Task<IActionResult> UpdateBook(int id)
        {
            BookEF book = await bookService.GettBookByID(id);
            return View("BookUpdate", book);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, string description, string title, string genre, decimal price)
        {
            await bookService.UpdateBook(id, description, title, genre, price);
            var books = await bookService.GettAllBooks();
            return View("Index",books);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

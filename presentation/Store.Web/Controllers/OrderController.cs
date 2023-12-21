using Microsoft.AspNetCore.Mvc;
using Store.Data.EF;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly IOrderRepository orderRepository;

        public OrderController(IBookRepository bookRepository, 
                              IOrderRepository orderRepository)
        {
            this.bookRepository = bookRepository;
            this.orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                var order = orderRepository.GetByID(cart.OrderId);
                OrderModel model = await Map(order);
                return View(model);
            }
            else
            {
                return View("Empty");
            }

            
        }

        private async Task<OrderModel> Map(Order order)
        {
            var bookIds = order.Items.Select(item => item.BookId);
            var books = await bookRepository.GetAllByIds(bookIds);
            var itemModels = from item in order.Items
                             join book in books on item.BookId equals book.Id
                             select new OrderItemModel
                             {
                                 BookId = book.Id,
                                 Title = book.TitleOf,
                                 Author = book.Author.FullName,
                                 Price = item.Price,
                                 Count = item.Count,
                             };
            return new OrderModel
            {
                Id = order.Id,
                Items = itemModels.ToArray(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalPrice,
            };
            return null;
        }

        public async Task<IActionResult> AddItem(int id)
        {
            Order order;
            Cart cart;

            if(HttpContext.Session.TryGetCart(out cart))
            {
                order = orderRepository.GetByID(cart.OrderId);
            }
            else
            {
                order = orderRepository.Create();
                cart = new Cart(order.Id);
            }

            var book = await bookRepository.GetById(id);
            order.AddItem(book, 1);
            orderRepository.Update(order);

            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;

            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Book", new {id});
            

            return null;
        }
    }
}

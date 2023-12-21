using Store.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Order
    {
        public int Id { get;}

        private List<OrderItem> items;
        public IReadOnlyCollection<OrderItem> Items
        {
            get { return items; }
        }

        public int TotalCount => items.Sum(item => item.Count);

        public decimal TotalPrice => items.Sum(item => item.Count * item.Price);

        public Order(int id, IEnumerable<OrderItem> items)
        {   
            if(items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            Id = id;

            this.items = new List<OrderItem>(items);
        }

        public void AddItem(BookEF book, int count) 
        { 
            if(book == null)
                throw new ArgumentNullException(nameof(book));

            var item = items.SingleOrDefault(x => x.BookId == book.Id);

            if(item == null)
            {
                items.Add(new OrderItem(book.Id, count, book.PriceOf));
            }
            else
            {
                items.Remove(item);
                items.Add(new OrderItem(book.Id, item.Count + count, book.PriceOf));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.EF
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> orders = new List<Order>();

        public Order Create()
        {
            int nextid = orders.Count + 1;
            var order = new Order(nextid, new OrderItem[0]);    
            orders.Add(order);
            return order;
        }

        public Order GetByID(int id)
        {
            return orders.Single(order => order.Id == id);
        }

        public void Update(Order order)
        {
            ;
        }
    }
}

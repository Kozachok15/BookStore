using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public interface IOrderRepository
    {
        public Order Create();

        public Order GetByID(int id);

        public void Update(Order order);
    }
}

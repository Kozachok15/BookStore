using System;
using System.Collections.Generic;

namespace Store.Entities
{
    public partial class OrderEF
    {
        public OrderEF()
        {
            OrderBooks = new HashSet<OrderBookEF>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Status { get; set; }

        public virtual ClientEF Client { get; set; } = null!;
        public virtual ICollection<OrderBookEF> OrderBooks { get; set; }
    }
}

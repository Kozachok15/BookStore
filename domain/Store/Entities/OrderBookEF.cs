using System;
using System.Collections.Generic;

namespace Store.Entities
{
    public partial class OrderBookEF
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int OrderId { get; set; }
        public int CountOf { get; set; }

        public virtual BookEF Book { get; set; } = null!;
        public virtual OrderEF Order { get; set; } = null!;
    }
}

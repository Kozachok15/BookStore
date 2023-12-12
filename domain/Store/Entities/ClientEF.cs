using System;
using System.Collections.Generic;

namespace Store.Entities
{
    public partial class ClientEF
    {
        public ClientEF()
        {
            Orders = new HashSet<OrderEF>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Phone { get; set; }
        public string Adres { get; set; } = null!;
        public string? Email { get; set; }

        public virtual ICollection<OrderEF> Orders { get; set; }
    }
}

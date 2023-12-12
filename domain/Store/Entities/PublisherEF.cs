using System;
using System.Collections.Generic;

namespace Store.Entities
{
    public partial class PublisherEF
    {
        public PublisherEF()
        {
            Books = new HashSet<BookEF>();
        }

        public int Id { get; set; }
        public string NameOf { get; set; } = null!;

        public virtual ICollection<BookEF> Books { get; set; }
    }
}

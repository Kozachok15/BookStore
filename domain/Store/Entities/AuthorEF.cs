using System;
using System.Collections.Generic;

namespace Store.Entities
{
    public partial class AuthorEF
    {
        public AuthorEF()
        {
            Books = new HashSet<BookEF>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;

        public virtual ICollection<BookEF> Books { get; set; }
    }
}

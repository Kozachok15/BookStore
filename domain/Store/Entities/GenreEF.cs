using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entities
{
    public partial class GenreEF
    {
        public GenreEF()
        {
            Books = new HashSet<BookEF>();
        }

        public int Id { get; set; }
        public string Name_of { get; set; } = null!;

        public virtual ICollection<BookEF> Books { get; set; }

    }
}

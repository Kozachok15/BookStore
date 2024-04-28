using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Store.Entities
{
    public partial class BookEF
    {
        public BookEF()
        {
            OrderBooks = new HashSet<OrderBookEF>();
        }

        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public string? GenreOf { get; set; }
        public string TitleOf { get; set; } = null!;
        public string IsbnOf { get; set; } = null!;
        public string? DescriptionOf { get; set; }
        public decimal PriceOf { get; set; }
        public byte[]? ImageOf { get; set; }

        public AuthorEF Author { get; set; } = null!;
        public PublisherEF Publisher { get; set; } = null!;
        public ICollection<OrderBookEF> OrderBooks { get; set; }        


    }
}

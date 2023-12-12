using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Store.Tests
{
    public class BookServiceTests
    {
        
        [Fact]
        public void GetAllByQuery_WithISBN_CallsGetAllByIsbn()
        {
            /*var bookRepositorySub = new Mock<IBookRepository>();
            string validIsbn = "ISBN 12345-12345";
            string validAuthor = "D. Knuth";
            string validTitle = "Art Of Programming";
            bookRepositorySub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                             .Returns(new[] { new Book(1, "", "", "") });
            bookRepositorySub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                             .Returns(new[] { new Book(2, "", "", "") });
            var bookService = new BookService(bookRepositorySub.Object);
            var actual = bookService.GettAllByQuery(validIsbn);

            Assert.Collection()*/

        }
        [Fact]
        public void GetAllByQuery_WithTitleOrAuthor_CallsGetAllByTitleOrAuthor()
        {

        }
    }
}

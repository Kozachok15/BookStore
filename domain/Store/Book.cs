using Store.Entities;
using System.Text.RegularExpressions;

namespace Store;
public class Book
{
    /*
    private readonly BookEF bookDto;
    private AuthorEF authorDto;
    private PublisherEF publisherDto;

    public int Id => bookDto.Id;
    public AuthorEF Author
    {
        get => authorDto;
        set => authorDto = new AuthorEF { Id = value.Id, FullName = value.FullName };
    }
    public PublisherEF Publisher
    {
        get => publisherDto;
        set
        {
            publisherDto = new PublisherEF { Id = value.Id, NameOf = value.NameOf };
        }
    }

    public string? GenreOf
    {
        get => bookDto.GenreOf;
        set => bookDto.GenreOf = value;
    }
    public string TitleOf
    {
        get => bookDto.TitleOf; 
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(nameof(TitleOf));

            bookDto.TitleOf = value;
        }
    }

    public string IsbnOf
    {
        get => bookDto.IsbnOf;
        set
        {
            if (TryFormatIsbn(value, out string formattedIsbn))
                bookDto.IsbnOf = formattedIsbn;

            throw new ArgumentException(nameof(IsbnOf));
        }
    }
    public string? DescriptionOf
    {
        get => bookDto.DescriptionOf;
        set => bookDto.DescriptionOf = value;
    }
    public decimal PriceOf
    {
        get => bookDto.PriceOf;
        set => bookDto.PriceOf = value;
    }
    public byte[]? ImageOf
    {
        get => bookDto.ImageOf;
        set => bookDto.ImageOf = value;
    }

    internal Book(BookEF bookDto)
    {
        this.bookDto = bookDto;
    }

    public static class Mapper
    {
        public static Book Map(BookEF bookDto)
        {
            return new Book(bookDto);
        }

        public static BookEF Map(Book domain)
        {
            return domain.bookDto;
        }
    }*/

    public static bool TryFormatIsbn(string isbn, out string formatedIsbn)
    {
        if (string.IsNullOrEmpty(isbn))
        {
            formatedIsbn = null;
            return false;
        }


        formatedIsbn = isbn.Replace("-", "").Replace(" ", "").ToUpper();

        return Regex.IsMatch(formatedIsbn, "^ISBN\\d{10}(\\d{3})?$");
    }

    public static bool IsIsbn(string isbn) => TryFormatIsbn(isbn, out string formatedIsbn);


    


}

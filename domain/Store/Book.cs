using System.Text.RegularExpressions;

namespace Store;
public class Book
{
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

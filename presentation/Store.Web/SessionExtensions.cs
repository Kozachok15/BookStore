using Store.Web.Models;
using System.Text;

namespace Store.Web
{
    public static class SessionExtensions
    {
        private static string key = "Cart";

        public static void Set(this ISession session, Cart cartValue)
        {
            if (cartValue == null)
                return;

            //stream - набор битов, потому что сессию можно записывать и читать только битами
            var stream = new MemoryStream();

            // using нужен для того, чтоб освободить память сразу после завершения работы, даже если будет вызвано исключение.
            // Т.е. когда запись закончится, работа прекратится, память освободится, но файл с записью останется
            // writer - позволит записать битами обычные значения. Если объяснять по-програмистски, то BinaryWriter - это паттерн, который позволяет привести один интерфейс к другому                                        
            using (var writer = new BinaryWriter(stream, Encoding.UTF8))
            {
                // теперь просто по очереди записываем в файл сессии все данные, которые нужны

                writer.Write(cartValue.OrderId);
                writer.Write(cartValue.TotalCount);
                writer.Write(cartValue.TotalPrice);               

                session.Set(key, stream.ToArray());
            } 

        }

        public static bool TryGetCart(this ISession session, out Cart cartValue)
        {
            // if session contains value with our key, return byte[] of our Cart values
            if (session.TryGetValue(key, out byte[] buffer)) 
            {
                using (var stream = new MemoryStream(buffer))
                using (var reader = new BinaryReader(stream, Encoding.UTF8))
                {
                    var orderID = reader.ReadInt32();
                    var totalCount = reader.ReadInt32();
                    var totalPrice = reader.ReadDecimal();

                    cartValue = new Cart(orderID)
                    {
                        TotalCount = totalCount,
                        TotalPrice = totalPrice, 
                    };

                }
                return true;
            }
            
            cartValue = null;
            return false;
        }

    }
}

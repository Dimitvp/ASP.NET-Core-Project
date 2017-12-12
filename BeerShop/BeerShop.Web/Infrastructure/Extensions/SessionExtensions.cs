namespace BeerShop.Web.Infrastructure.Extensions
{
    using BeerShop.Web.Areas.Shopping.Models.Orders;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    public static class SessionExtensions
    {
        public static void Set(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
                                  JsonConvert.DeserializeObject<T>(value);
        }

        public static ShoppingCart GetShoppingCart(this ISession session)
        {
            var shoppingCart = session.Get<ShoppingCart>(WebConstants.MyCart);
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart();
                session.Set(WebConstants.MyCart, shoppingCart);
            }

            return shoppingCart;
        }

        public static bool IsExists(this ISession session, string key)
        {
            return session.Get(key) != null;
        }
    }
}

namespace BeerShop.Services.Shopping
{
    using System.Collections.Generic;

    public interface IShoppingOrderService
    {
        bool Create(IDictionary<int, int> beers,
                    IDictionary<int, int> accessories,
                    IDictionary<int, int> giftSets,
                    IDictionary<int, int> glasses,
                    decimal totalPrice,
                    int addressId,
                    string userId);
    }
}

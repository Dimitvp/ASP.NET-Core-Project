namespace BeerShop.Services
{
    using BeerShop.Services.Models.Orders;
    using System.Collections.Generic;

    public interface IOrderService
    {
        IEnumerable<OrderListingServiceModel> All(string userId);
    }
}

namespace BeerShop.Services.Administration
{
    using BeerShop.Models.Enums;
    using BeerShop.Services.Administration.Models.Orders;
    using System.Collections.Generic;

    using static ServiceConstants;

    public interface IAdminOrderService
    {
        IEnumerable<OrderListingServiceModel> AllListing(int page = DefaultPage, int pageSize = DefaultPageSize);

        OrderDetailsServiceModel ById(int id);

        bool ChangeStatus(int id, OrderStatus status);

        int Total();

        int TotalWaiting();
    }
}

namespace BeerShop.Web.Areas.Administration.Models.Orders
{
    using Services.Administration.Models.Orders;
    using System.Collections.Generic;

    public class OrderPageListingViewModel : Pager
    {
        public IEnumerable<OrderListingServiceModel> Orders { get; set; }
    }
}

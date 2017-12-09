namespace BeerShop.Services.Administration.Models.Orders
{
    using BeerShop.Models;
    using BeerShop.Models.Enums;
    using Common.Mapping;
    using System;

    public class OrderListingServiceModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public OrderStatus Status { get; set; }
    }
}

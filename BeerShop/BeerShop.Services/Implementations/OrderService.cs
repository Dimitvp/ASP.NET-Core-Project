namespace BeerShop.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models.Orders;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderService : IOrderService
    {
        private readonly BeerShopDbContext db;

        public OrderService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<OrderListingServiceModel> All(string userId)
            => this.db.Orders
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.Date)
                .ProjectTo<OrderListingServiceModel>()
                .ToList();
    }
}

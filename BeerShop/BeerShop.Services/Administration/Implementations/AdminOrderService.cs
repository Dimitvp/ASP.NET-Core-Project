namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Models.Enums;
    using Data;
    using Models.Orders;
    using System.Collections.Generic;
    using System.Linq;

    using static ServiceConstants;

    public class AdminOrderService : IAdminOrderService
    {
        private readonly BeerShopDbContext db;

        public AdminOrderService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<OrderListingServiceModel> AllListing(int page = DefaultPage, int pageSize = DefaultPageSize)
            => this.db.Orders
                .OrderByDescending(o => o.Date)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<OrderListingServiceModel>()
                .ToList();

        public OrderDetailsServiceModel ById(int id)
            => this.db.Orders
                .Where(o => o.Id == id)
                .ProjectTo<OrderDetailsServiceModel>()
                .FirstOrDefault();

        public bool ChangeStatus(int id, OrderStatus status)
        {
            var order = this.db.Orders.Find(id);

            if (order == null)
            {
                return false;
            }

            order.Status = status;
            this.db.SaveChanges();

            return true;
        }

        public int Total()
            => this.db.Orders.Count();

        public int TotalWaiting()
            => this.db.Orders
                .Where(o => o.Status == OrderStatus.Processing)
                .Count();
    }
}

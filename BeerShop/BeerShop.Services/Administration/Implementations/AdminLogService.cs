namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Data;
    using Models.Logs;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminLogService : IAdminLogService
    {
        private readonly BeerShopDbContext db;

        public AdminLogService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<LogListingModel> AllListing()
            => this.db.Logs
                .ProjectTo<LogListingModel>()
                .ToList();

        public void Clear()
        {
            var logs = this.db.Logs;
            this.db.Logs.RemoveRange(logs);
            this.db.SaveChanges();
        }
    }
}

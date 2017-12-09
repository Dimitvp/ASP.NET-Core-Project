namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models.Logs;
    using System.Collections.Generic;
    using System.Linq;

    using static ServiceConstants;

    public class AdminLogService : IAdminLogService
    {
        private readonly BeerShopDbContext db;

        public AdminLogService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<LogListingServiceModel> AllListing(int page = DefaultPage, int pageSize = DefaultPageSize)
            => this.db.Logs
                .OrderByDescending(l=> l.Date)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<LogListingServiceModel>()
                .ToList();

        public int Total()
            => this.db.Logs.Count();

        public void Clear()
        {
            var logs = this.db.Logs;
            this.db.Logs.RemoveRange(logs);
            this.db.SaveChanges();
        }
    }
}

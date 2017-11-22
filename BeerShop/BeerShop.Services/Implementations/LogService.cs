using System.Collections.Generic;
using BeerShop.Services.Models.Logs;
using BeerShop.Data;
using System.Linq;

namespace BeerShop.Services.Implementations
{
    public class LogService : ILogService
    {
        private readonly BeerShopDbContext db;

        public LogService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<LogListingModel> AllListing()
            => this.db.Logs
                .Select(l => new LogListingModel
                {
                    Username = l.Username,
                    LogType = l.LogType,
                    Table = l.Table,
                    Date = l.Date
                })
                .ToList();

        public void Clear()
        {
            var logs = this.db.Logs;
            this.db.Logs.RemoveRange(logs);
            this.db.SaveChanges();
        }
    }
}

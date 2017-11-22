namespace BeerShop.Services
{
    using BeerShop.Services.Models.Logs;
    using System.Collections.Generic;

    public interface ILogService
    {
        IEnumerable<LogListingModel> AllListing();

        void Clear();
    }
}

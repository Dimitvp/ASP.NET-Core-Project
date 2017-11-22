namespace BeerShop.Services.Administration
{
    using Models.Logs;
    using System.Collections.Generic;

    public interface ILogService
    {
        IEnumerable<LogListingModel> AllListing();

        void Clear();
    }
}

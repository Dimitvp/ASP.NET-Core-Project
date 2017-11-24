namespace BeerShop.Services.Administration
{
    using Models.Logs;
    using System.Collections.Generic;

    public interface IAdminLogService
    {
        IEnumerable<LogListingModel> AllListing();

        void Clear();
    }
}

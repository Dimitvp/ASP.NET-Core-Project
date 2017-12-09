namespace BeerShop.Services.Administration
{
    using Models.Logs;
    using System.Collections.Generic;

    using static ServiceConstants;

    public interface IAdminLogService
    {
        IEnumerable<LogListingServiceModel> AllListing(int page = DefaultPage, int pageSize = DefaultPageSize);

        int Total();

        void Clear();
    }
}

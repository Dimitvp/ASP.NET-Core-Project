namespace BeerShop.Services.Shopping
{
    using Models.Accessories;
    using System.Collections.Generic;

    using static ServiceConstants;

    public interface IShoppingAccessoryService
    {
        IEnumerable<AccessoryListingServiceModel> LatestListing();

        IEnumerable<AccessoryListingServiceModel> All(int page = DefaultPage, int pageSize = DefaultPageSize);

        IEnumerable<AccessoryListingServiceModel> Search(string searchTerm);

        IEnumerable<AccessoryListingServiceModel> ByIds(IEnumerable<int> ids);

        AccessoryDetailsServiceModel ById(int id);

        int Total();
    }
}

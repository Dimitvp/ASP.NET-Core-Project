namespace BeerShop.Services.Shopping
{
    using Models.GiftSets;
    using System.Collections.Generic;

    using static ServiceConstants;

    public interface IShoppingGiftSetService
    {
        IEnumerable<GiftSetListingServiceModel> LatestListing();

        IEnumerable<GiftSetListingServiceModel> All(int page = DefaultPage, int pageSize = DefaultPageSize);

        IEnumerable<GiftSetListingServiceModel> Search(string searchTerm);

        IEnumerable<GiftSetOrderServiceModel> ByIds(IDictionary<int, int> ids);

        GiftSetDetailsServiceModel ById(int id);

        int Total();

        bool Exists(int id);
    }
}

namespace BeerShop.Services.Shopping
{
    using Models.GiftSets;
    using System.Collections.Generic;

    public interface IShoppingGiftSetService
    {
        IEnumerable<LatestGiftSetListingServiceModel> LatestListing();
    }
}

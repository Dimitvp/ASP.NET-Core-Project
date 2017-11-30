namespace BeerShop.Services.Shopping
{
    using Models.Accessories;
    using System.Collections.Generic;

    public interface IShoppingAccessoriesService
    {
        IEnumerable<LatestAccessoryListingServiceModel> LatestListing();
    }
}

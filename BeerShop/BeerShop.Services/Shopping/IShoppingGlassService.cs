namespace BeerShop.Services.Shopping
{
    using Models.Glasses;
    using System.Collections.Generic;

    public interface IShoppingGlassService
    {
        IEnumerable<LatestGlassListingServiceModel> LatestListing();
    }
}

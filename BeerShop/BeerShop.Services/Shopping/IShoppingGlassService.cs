namespace BeerShop.Services.Shopping
{
    using Models.Glasses;
    using System.Collections.Generic;

    using static ServiceConstants;

    public interface IShoppingGlassService
    {
        IEnumerable<GlassListingServiceModel> LatestListing();

        IEnumerable<GlassListingServiceModel> All(int page = DefaultPage, int pageSize = DefaultPageSize);

        GlassDetailsServiceModel ById(int id);

        int Total();
    }
}

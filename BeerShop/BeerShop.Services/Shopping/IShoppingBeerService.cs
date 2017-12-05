namespace BeerShop.Services.Shopping
{
    using BeerShop.Models.Enums;
    using Models.Beers;
    using System.Collections.Generic;

    using static ServiceConstants;

    public interface IShoppingBeerService
    {
        IEnumerable<BeerListingServiceModel> All(int page = DefaultPage, int pageSize = DefaultPageSize);

        IEnumerable<BeerListingServiceModel> LatestListing();

        IEnumerable<BeerListingServiceModel> BeersByCountry(int countryId, int page = DefaultPage, int pageSize = DefaultPageSize);

        IEnumerable<BeerListingServiceModel> BeersByStyle(int styleId, int page = DefaultPage, int pageSize = DefaultPageSize);

        IEnumerable<BeerListingServiceModel> BeersByColor(BeerColor color, int page = DefaultPage, int pageSize = DefaultPageSize);

        IEnumerable<BeerListingServiceModel> Search(string searchTerm);

        IDictionary<BeerColor, int> ColorsWithBeersCount();

        BeerDetailsServiceModel ById(int id);

        int Total();

        int TotalByCountry(int countryId);

        int TotalByStyle(int styleId);

        int TotalByColor(BeerColor color);
    }
}

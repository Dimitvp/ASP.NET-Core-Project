namespace BeerShop.Services.Shopping
{
    using Models.Beers;
    using System.Collections.Generic;

    public interface IShoppingBeerService
    {
        IEnumerable<LatestBeerListingServiceModel> LatestListing();

        IEnumerable<BeerByCountryServiceModel> BeersByCountry(int countryId);
    }
}

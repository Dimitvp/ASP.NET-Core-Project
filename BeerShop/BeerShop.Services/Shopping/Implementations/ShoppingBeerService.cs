namespace BeerShop.Services.Shopping.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Data;
    using Models.Beers;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingBeerService : IShoppingBeerService
    {
        private readonly BeerShopDbContext db;

        public ShoppingBeerService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<LatestBeerListingServiceModel> LatestListing()
            => this.db.Beers
                .OrderByDescending(b => b.Id)
                .Take(ServiceConstants.ListingNumber)
                .ProjectTo<LatestBeerListingServiceModel>()
                .ToList();
    }
}

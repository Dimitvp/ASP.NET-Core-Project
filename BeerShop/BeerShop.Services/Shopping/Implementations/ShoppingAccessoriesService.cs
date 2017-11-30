namespace BeerShop.Services.Shopping.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Data;
    using Models.Accessories;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingAccessoriesService : IShoppingAccessoriesService
    {
        private readonly BeerShopDbContext db;

        public ShoppingAccessoriesService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<LatestAccessoryListingServiceModel> LatestListing()
            => this.db.Accessories
            .OrderByDescending(a => a.Id)
            .Take(ServiceConstants.ListingNumber)
            .ProjectTo<LatestAccessoryListingServiceModel>()
            .ToList();
    }
}

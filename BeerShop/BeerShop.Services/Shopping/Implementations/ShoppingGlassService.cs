namespace BeerShop.Services.Shopping.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Data;
    using Models.Glasses;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingGlassService : IShoppingGlassService
    {
        private readonly BeerShopDbContext db;

        public ShoppingGlassService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<LatestGlassListingServiceModel> LatestListing()
            => this.db.Glasses
                .OrderByDescending(g => g.Id)
                .Take(ServiceConstants.ListingNumber)
                .ProjectTo<LatestGlassListingServiceModel>()
                .ToList();
    }
}

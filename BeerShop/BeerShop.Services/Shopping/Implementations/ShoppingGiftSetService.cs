namespace BeerShop.Services.Shopping.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Data;
    using Models.GiftSets;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingGiftSetService : IShoppingGiftSetService
    {
        private readonly BeerShopDbContext db;

        public ShoppingGiftSetService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<LatestGiftSetListingServiceModel> LatestListing()
            => this.db.GiftSets
                .OrderByDescending(gs => gs.Id)
                .Take(ServiceConstants.ListingNumber)
                .ProjectTo<LatestGiftSetListingServiceModel>()
                .ToList();
    }
}

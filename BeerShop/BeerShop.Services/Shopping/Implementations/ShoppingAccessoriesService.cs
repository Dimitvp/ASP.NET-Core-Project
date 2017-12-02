namespace BeerShop.Services.Shopping.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models.Accessories;
    using System.Collections.Generic;
    using System.Linq;

    using static ServiceConstants;

    public class ShoppingAccessoryService : IShoppingAccessoryService
    {
        private readonly BeerShopDbContext db;

        public ShoppingAccessoryService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AccessoryListingServiceModel> LatestListing()
            => this.db.Accessories
            .OrderByDescending(a => a.Id)
            .Take(ListingNumber)
            .ProjectTo<AccessoryListingServiceModel>()
            .ToList();

        public IEnumerable<AccessoryListingServiceModel> All(int page = DefaultPage, int pageSize = DefaultPageSize)
            => this.db.Accessories
                .OrderBy(a => a.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<AccessoryListingServiceModel>()
                .ToList();

        public AccessoryDetailsServiceModel ById(int id)
            => this.db.Accessories
                .Where(a => a.Id == id)
                .ProjectTo<AccessoryDetailsServiceModel>()
                .FirstOrDefault();

        public int Total()
            => this.db.Accessories.Count();
    }
}

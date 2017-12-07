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

        public IEnumerable<AccessoryListingServiceModel> Search(string searchTerm)
        {
            searchTerm = searchTerm ?? string.Empty;
            return this.db.Accessories
                   .Where(b => b.Name.ToLower().Contains(searchTerm.ToLower()))
                   .ProjectTo<AccessoryListingServiceModel>()
                   .ToList();
        }

        public IEnumerable<AccessoryOrderServiceModel> ByIds(IDictionary<int, int> ids)
        {
            var accessories = new List<AccessoryOrderServiceModel>();

            foreach (var id in ids)
            {
                var accessory = this.db.Accessories
                         .Where(a => a.Id == id.Key && id.Value > 0)
                         .ProjectTo<AccessoryOrderServiceModel>(new { quantity = id.Value })
                         .FirstOrDefault();

                if (accessories != null)
                {
                    accessories.Add(accessory);
                }
            }

            return accessories;
        }

        public AccessoryDetailsServiceModel ById(int id)
            => this.db.Accessories
                .Where(a => a.Id == id)
                .ProjectTo<AccessoryDetailsServiceModel>()
                .FirstOrDefault();

        public int Total()
            => this.db.Accessories.Count();

    }
}

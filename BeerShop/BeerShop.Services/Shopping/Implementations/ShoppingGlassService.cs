namespace BeerShop.Services.Shopping.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models.Glasses;
    using System.Collections.Generic;
    using System.Linq;

    using static ServiceConstants;

    public class ShoppingGlassService : IShoppingGlassService
    {
        private readonly BeerShopDbContext db;

        public ShoppingGlassService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<GlassListingServiceModel> LatestListing()
            => this.db.Glasses
                .OrderByDescending(g => g.Id)
                .Take(ListingNumber)
                .ProjectTo<GlassListingServiceModel>()
                .ToList();

        public IEnumerable<GlassListingServiceModel> All(int page = DefaultPage, int pageSize = DefaultPageSize)
            => this.db.Glasses
                .OrderBy(g => g.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<GlassListingServiceModel>()
                .ToList();

        public IEnumerable<GlassListingServiceModel> Search(string searchTerm)
        {
            searchTerm = searchTerm ?? string.Empty;
            return this.db.Glasses
                   .Where(b => b.Name.ToLower().Contains(searchTerm.ToLower()))
                   .ProjectTo<GlassListingServiceModel>()
                   .ToList();
        }

        public IEnumerable<GlassOrderServiceModel> ByIds(IDictionary<int, int> ids)
        {
            var glasses = new List<GlassOrderServiceModel>();

            foreach (var id in ids)
            {
                glasses.Add(this.db.Glasses
                        .Where(g => g.Id == id.Key)
                        .ProjectTo<GlassOrderServiceModel>(new { quantity = id.Value })
                        .FirstOrDefault());
            }

            return glasses;
        }

        public GlassDetailsServiceModel ById(int id)
            => this.db.Glasses
                .Where(g => g.Id == id)
                .ProjectTo<GlassDetailsServiceModel>()
                .FirstOrDefault();

        public int Total()
            => this.db.Glasses.Count();

    }
}

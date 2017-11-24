namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Data;
    using Models.Breweries;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminBreweryService : IAdminBreweryService
    {
        private readonly BeerShopDbContext db;

        public AdminBreweryService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<BrewerySelectModel> AllForSelect()
            => this.db.Breweries
                .OrderBy(b => b.Name)
                .ProjectTo<BrewerySelectModel>()
                .ToList();
    }
}

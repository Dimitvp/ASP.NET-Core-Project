namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Data;
    using Models.Breweries;
    using System.Collections.Generic;
    using System.Linq;

    public class BreweryService : IBreweryService
    {
        private readonly BeerShopDbContext db;

        public BreweryService(BeerShopDbContext db)
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

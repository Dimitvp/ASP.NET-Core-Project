namespace BeerShop.Services.Implementations
{
    using BeerShop.Data;
    using BeerShop.Services.Models.Breweries;
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
                .OrderBy(b=> b.Name)
                .Select(b => new BrewerySelectModel
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToList();
    }
}

namespace BeerShop.Services.Shopping.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models.Countries;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingCountryService : IShoppingCountryService
    {
        private readonly BeerShopDbContext db;

        public ShoppingCountryService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CountryWithBeersServiceModel> CountriesWithBeersCount()
            => this.db.Countries
                .OrderBy(c => c.Name)
                .ProjectTo<CountryWithBeersServiceModel>()
                .ToList();
    }
}

namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Models;
    using BeerShop.Models.Enums;
    using Data;
    using Models.Countries;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminCountryService : IAdminCountryService
    {
        private readonly BeerShopDbContext db;

        public AdminCountryService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CountryListingServiceModel> All()
            => this.db.Countries
                .OrderBy(c => c.Name)
                .ProjectTo<CountryListingServiceModel>()
                .ToList();

        public void Create(string name, Continent continent)
        {
            var country = new Country
            {
                Name = name,
                Continent = continent
            };

            this.db.Countries.Add(country);
            this.db.SaveChanges();
        }
    }
}

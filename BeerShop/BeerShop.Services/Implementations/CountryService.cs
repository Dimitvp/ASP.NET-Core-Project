﻿namespace BeerShop.Services.Implementations
{
    using BeerShop.Data;
    using BeerShop.Models;
    using BeerShop.Models.Enums;
    using BeerShop.Services.Models.Countries;
    using System.Collections.Generic;
    using System.Linq;

    public class CountryService : ICountryService
    {
        private readonly BeerShopDbContext db;

        public CountryService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CountryListingModel> All()
            => this.db.Countries
                .OrderBy(c => c.Name)
                .Select(c => new CountryListingModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Continent = c.Continent
                })
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

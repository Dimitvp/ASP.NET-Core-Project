namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Models;
    using BeerShop.Models.Enums;
    using Data;
    using Models.Countries;
    using System.Collections.Generic;
    using System.Linq;

    using static ServiceConstants;

    public class AdminCountryService : IAdminCountryService
    {
        private readonly BeerShopDbContext db;

        public AdminCountryService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CountryListingServiceModel> AllListing(int page = DefaultPage, int pageSize = DefaultPageSize)
            => this.db.Countries
                .OrderBy(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<CountryListingServiceModel>()
                .ToList();

        public IEnumerable<CountrySelectServiceModel> AllForSelect()
            => this.db.Countries
                .OrderBy(c => c.Name)
                .ProjectTo<CountrySelectServiceModel>()
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

        public CountryListingServiceModel ById(int id)
            => this.db.Countries
                .Where(c => c.Id == id)
                .ProjectTo<CountryListingServiceModel>()
                .FirstOrDefault();

        public bool Delete(int id)
        {
            var country = this.db.Countries.Find(id);

            if (country == null)
            {
                return false;
            }

            this.db.Countries.Remove(country);
            this.db.SaveChanges();

            return true;
        }

        public int Total()
            => this.db.Countries.Count();

        
    }
}

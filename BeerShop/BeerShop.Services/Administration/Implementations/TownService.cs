namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Data;
    using BeerShop.Models;
    using Models.Towns;
    using System.Collections.Generic;
    using System.Linq;

    public class TownService : ITownService
    {
        private readonly BeerShopDbContext db;

        public TownService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<TownListingModel> AllListing()
            => this.db.Towns
                .OrderBy(t => t.Name)
                .ProjectTo<TownListingModel>()
                .ToList();

        public void Create(string name, string zipcode, int countryId)
        {
            var town = new Town
            {
                Name = name,
                ZipCode = zipcode,
                CountryId = countryId
            };

            this.db.Towns.Add(town);
            this.db.SaveChanges();
        }

        public TownEditModel ById(int id)
            => this.db.Towns
                .Where(t => t.Id == id)
                .ProjectTo<TownEditModel>()
                .FirstOrDefault();

        public void Edit(int id, string name, string zipCode, int countryId)
        {
            var town = this.db.Towns.Find(id);

            if (town == null)
            {
                return;
            }

            town.Name = name;
            town.ZipCode = zipCode;
            town.CountryId = countryId;

            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var town = this.db.Towns.Find(id);

            if (town == null)
            {
                return;
            }

            this.db.Towns.Remove(town);
            this.db.SaveChanges();
        }
    }
}

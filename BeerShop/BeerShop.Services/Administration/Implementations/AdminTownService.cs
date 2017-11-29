namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Models;
    using Data;
    using Models.Towns;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminTownService : IAdminTownService
    {
        private readonly BeerShopDbContext db;

        public AdminTownService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<TownListingServiceModel> AllListing()
            => this.db.Towns
                .OrderBy(t => t.Name)
                .ProjectTo<TownListingServiceModel>()
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

        public TownEditServiceModel ById(int id)
            => this.db.Towns
                .Where(t => t.Id == id)
                .ProjectTo<TownEditServiceModel>()
                .FirstOrDefault();

        public bool Edit(int id, string name, string zipCode, int countryId)
        {
            var town = this.db.Towns.Find(id);

            if (town == null)
            {
                return false;
            }

            town.Name = name;
            town.ZipCode = zipCode;
            town.CountryId = countryId;

            this.db.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var town = this.db.Towns.Find(id);

            if (town == null)
            {
                return false;
            }

            this.db.Towns.Remove(town);
            this.db.SaveChanges();

            return true;
        }

        public IEnumerable<TownSelectServiceModel> AllForSelect()
            => this.db.Towns
            .OrderBy(t => t.Name)
            .ProjectTo<TownSelectServiceModel>()
            .ToList();
    }
}

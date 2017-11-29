namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Models;
    using Data;
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

        public IEnumerable<BreweryListingServiceModel> AllListing(int page = ServiceConstants.DefaultPage, int pageSize = ServiceConstants.DefaultPageSize)
            => this.db.Breweries
            .OrderBy(b => b.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ProjectTo<BreweryListingServiceModel>()
            .ToList();

        public IEnumerable<BrewerySelectServiceModel> AllForSelect()
            => this.db.Breweries
                .OrderBy(b => b.Name)
                .ProjectTo<BrewerySelectServiceModel>()
                .ToList();

        public void Create(string name, string address, int townId)
        {
            var brewery = new Brewery
            {
                Name = name,
                Address = address,
                TownId = townId
            };

            this.db.Breweries.Add(brewery);
            this.db.SaveChanges();
        }

        public int Total()
            => this.db.Breweries.Count();

        public BreweryEditServiceModel ById(int id)
            => this.db.Breweries
            .Where(b => b.Id == id)
            .ProjectTo<BreweryEditServiceModel>()
            .FirstOrDefault();

        public bool Edit(int id, string name, string adress, int townId)
        {
            var brewery = this.db.Breweries.Find(id);

            if (brewery == null)
            {
                return false;
            }

            brewery.Name = name;
            brewery.Address = adress;
            brewery.TownId = townId;

            this.db.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var brewery = this.db.Breweries.Find(id);

            if (brewery == null)
            {
                return false;
            }

            this.db.Breweries.Remove(brewery);
            this.db.SaveChanges();

            return true;
        }
    }
}
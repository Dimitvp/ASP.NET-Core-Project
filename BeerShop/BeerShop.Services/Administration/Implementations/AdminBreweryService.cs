namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Data;
    using BeerShop.Models;
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

        public IEnumerable<BreweryListingModel> AllListing(int page = 1, int pageSize = 10)
            => this.db.Breweries
            .OrderBy(b => b.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ProjectTo<BreweryListingModel>()
            .ToList();

        public IEnumerable<BrewerySelectModel> AllForSelect()
            => this.db.Breweries
                .OrderBy(b => b.Name)
                .ProjectTo<BrewerySelectModel>()
                .ToList();

        public void Create(string name, string address, int townId)
        {
            var brewery = new Brewery
            {
                Name = name,
                Adress = address,
                TownId = townId
            };

            this.db.Breweries.Add(brewery);
            this.db.SaveChanges();
        }

        public int Total()
            => this.db.Breweries.Count();

        public BreweryEditModel ById(int id)
            => this.db.Breweries
            .Where(b => b.Id == id)
            .ProjectTo<BreweryEditModel>()
            .FirstOrDefault();

        public void Edit(int id, string name, string adress, int townId)
        {
            var brewery = this.db.Breweries.Find(id);

            if (brewery == null)
            {
                return;
            }

            brewery.Name = name;
            brewery.Adress = adress;
            brewery.TownId = townId;

            this.db.SaveChanges();
        }
    }
}
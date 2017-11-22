namespace BeerShop.Services.Implementations
{
    using BeerShop.Data;
    using BeerShop.Models;
    using BeerShop.Services.Models.Beers;
    using System.Collections.Generic;
    using System.Linq;

    public class BeerService : IBeerService
    {
        private readonly BeerShopDbContext db;

        public BeerService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<BeerListingModel> AllListing()
            => this.db.Beers
                .OrderBy(b=> b.Name)
                .Select(b => new BeerListingModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Brewery = b.Brewery.Name,
                    Price = b.Price,
                    Quantity = b.Quantity,
                    Style = b.Style.Name
                })
                .ToList();

        public void Create(string name, decimal price, int quantity, string description, int styleId, int breweryId)
        {
            var beer = new Beer
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                Description = description,
                StyleId = styleId,
                BreweryId = breweryId
            };

            this.db.Beers.Add(beer);
            this.db.SaveChanges();
        }

        public BeerEditModel ById(int id)
            => this.db.Beers
                .Where(b => b.Id == id)
                .Select(b => new BeerEditModel
                {
                    Name = b.Name,
                    Price = b.Price,
                    Quantity = b.Quantity,
                    BreweryId = b.BreweryId,
                    StyleId = b.StyleId,
                    Description = b.Description
                })
                .FirstOrDefault();

        public void Edit(int id, string name, decimal price, int quantity, int styleId, int breweryId)
        {
            var beer = this.db.Beers.Find(id);

            if (beer == null)
            {
                return;
            }

            beer.Name = name;
            beer.Price = price;
            beer.Quantity = quantity;
            beer.StyleId = styleId;
            beer.BreweryId = breweryId;

            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var beer = this.db.Beers.Find(id);

            if (beer == null)
            {
                return;
            }

            this.db.Beers.Remove(beer);
            this.db.SaveChanges();
        }
    }
}

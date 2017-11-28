namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Data;
    using BeerShop.Models.Enums;
    using BeerShop.Models.Products;
    using Models.Beers;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminBeerService : IAdminBeerService
    {
        private readonly BeerShopDbContext db;

        public AdminBeerService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<BeerListingModel> AllListing(string searchTerm, int page = 1, int pageSize = 10)
        {
            var beers = this.db.Beers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                beers = beers.Where(b => b.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return beers
                .OrderByDescending(b => b.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BeerListingModel>()
                .ToList();
        }

        public int Total(string searchTerm)
        {
            var beers = this.db.Beers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                beers = beers.Where(b => b.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return beers.Count();
        }

        public void Create(
            string name,
            decimal price,
            int quantity,
            string description,
            double alcohol,
            string servingTemp,
            BeerColor color,
            int bitterness,
            int density,
            int sweetness,
            int gasification,
            int styleId,
            int breweryId)
        {
            var beer = new Beer
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                Description = description,
                Alcohol = alcohol,
                ServingTemp = servingTemp,
                Color = color,
                Bitterness = bitterness,
                Density = density,
                Sweetness = sweetness,
                Gasification = gasification,
                StyleId = styleId,
                BreweryId = breweryId
            };

            this.db.Beers.Add(beer);
            this.db.SaveChanges();
        }

        public BeerEditModel ById(int id)
            => this.db.Beers
                .Where(b => b.Id == id)
                .ProjectTo<BeerEditModel>()
                .FirstOrDefault();

        public void Edit(
            int id,
            string name,
            decimal price,
            int quantity,
            string description,
            double alcohol,
            string servingTemp,
            BeerColor color,
            int bitterness,
            int density,
            int sweetness,
            int gasification,
            int styleId,
            int breweryId)
        {
            var beer = this.db.Beers.Find(id);

            if (beer == null)
            {
                return;
            }

            beer.Name = name;
            beer.Price = price;
            beer.Quantity = quantity;
            beer.Description = description;
            beer.Alcohol = alcohol;
            beer.ServingTemp = servingTemp;
            beer.Color = color;
            beer.Bitterness = bitterness;
            beer.Density = density;
            beer.Sweetness = sweetness;
            beer.Gasification = gasification;
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

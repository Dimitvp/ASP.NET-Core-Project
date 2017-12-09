namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Models.Enums;
    using BeerShop.Models.Products;
    using Data;
    using Models.Beers;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class AdminBeerService : IAdminBeerService
    {
        private readonly BeerShopDbContext db;

        public AdminBeerService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<BeerListingServiceModel> AllListing(string searchTerm, int page = ServiceConstants.DefaultPage, int pageSize = ServiceConstants.DefaultPageSize)
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
                .ProjectTo<BeerListingServiceModel>()
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
            int volume,
            string servingTemp,
            BeerColor color,
            int bitterness,
            int density,
            int sweetness,
            int gasification,
            int styleId,
            int breweryId,
            string image)
        {
            var beer = new Beer
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                Description = description,
                Alcohol = alcohol,
                Volume = volume,
                ServingTemp = servingTemp,
                Color = color,
                Bitterness = bitterness,
                Density = density,
                Sweetness = sweetness,
                Gasification = gasification,
                StyleId = styleId,
                BreweryId = breweryId,
                Image = image
            };

            this.db.Beers.Add(beer);
            this.db.SaveChanges();
        }

        public BeerEditServiceModel ById(int id)
            => this.db.Beers
                .Where(b => b.Id == id)
                .ProjectTo<BeerEditServiceModel>()
                .FirstOrDefault();

        public bool Edit(
            int id,
            string name,
            decimal price,
            int quantity,
            string description,
            double alcohol,
            int volume,
            string servingTemp,
            BeerColor color,
            int bitterness,
            int density,
            int sweetness,
            int gasification,
            int styleId,
            int breweryId,
            string image)
        {
            var beer = this.db.Beers.Find(id);

            if (beer == null)
            {
                return false;
            }

            beer.Name = name;
            beer.Price = price;
            beer.Quantity = quantity;
            beer.Description = description;
            beer.Alcohol = alcohol;
            beer.Volume = volume;
            beer.ServingTemp = servingTemp;
            beer.Color = color;
            beer.Bitterness = bitterness;
            beer.Density = density;
            beer.Sweetness = sweetness;
            beer.Gasification = gasification;
            beer.StyleId = styleId;
            beer.BreweryId = breweryId;

            if (!string.IsNullOrWhiteSpace(image))
            {
                beer.Image = image;
            }

            this.db.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var beer = this.db.Beers.Find(id);

            if (beer == null)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(beer.Image))
            {
                var filePath = Path
                .Combine(Directory.GetCurrentDirectory(), "wwwroot",
                "Images",
                "Beers",
                beer.Image);

                File.Delete(filePath);

            }

            this.db.Beers.Remove(beer);
            this.db.SaveChanges();

            return true;
        }

        public string GetName(int id)
            => this.db.Beers
                .Where(b => b.Id == id)
                .Select(b => b.Name)
                .FirstOrDefault();
    }
}

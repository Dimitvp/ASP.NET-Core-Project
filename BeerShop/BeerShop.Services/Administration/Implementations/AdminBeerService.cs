namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Data;
    using BeerShop.Models;
    using Microsoft.AspNetCore.Http;
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

        public IEnumerable<BeerListingModel> AllListing(string searchTerm, int page = 1, int pageSize = 10)
        {
            var beers = this.db.Beers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                beers = beers.Where(b => b.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return beers
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .OrderByDescending(b => b.Id)
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
            int styleId,
            int breweryId,
            IFormFile image)
        {
            var memoryStream = new MemoryStream();
            using (memoryStream)
            {
                image.CopyTo(memoryStream);
            }

            var beer = new Beer
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                Description = description,
                StyleId = styleId,
                BreweryId = breweryId,
                Image = memoryStream.ToArray()
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
            int styleId,
            int breweryId,
            IFormFile image)
        {
            var beer = this.db.Beers.Find(id);

            if (beer == null)
            {
                return;
            }

            var memoryStream = new MemoryStream();
            using (memoryStream)
            {
                image.CopyTo(memoryStream);
            }

            beer.Name = name;
            beer.Price = price;
            beer.Quantity = quantity;
            beer.StyleId = styleId;
            beer.BreweryId = breweryId;
            beer.Image = memoryStream.ToArray();

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

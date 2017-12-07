namespace BeerShop.Services.Shopping.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Models.Enums;
    using Data;
    using Models.Beers;
    using System.Collections.Generic;
    using System.Linq;

    using static ServiceConstants;

    public class ShoppingBeerService : IShoppingBeerService
    {
        private readonly BeerShopDbContext db;

        public ShoppingBeerService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<BeerListingServiceModel> All(int page = DefaultPage, int pageSize = DefaultPageSize)
            => this.db.Beers
                .OrderBy(b => b.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BeerListingServiceModel>()
                .ToList();

        public IEnumerable<BeerListingServiceModel> LatestListing()
            => this.db.Beers
                .OrderByDescending(b => b.Id)
                .Take(ListingNumber)
                .ProjectTo<BeerListingServiceModel>()
                .ToList();


        public IEnumerable<BeerOrderServiceModel> ByIds(IDictionary<int, int> ids)
        {
            var beers = new List<BeerOrderServiceModel>();

            foreach (var id in ids)
            {
                var beer = this.db.Beers
                      .Where(b => b.Id == id.Key && id.Value > 0)
                      .ProjectTo<BeerOrderServiceModel>(new { quantity = id.Value })
                      .FirstOrDefault();

                if (beer != null)
                {
                    beers.Add(beer);
                }
            }

            return beers;
        }

        public IEnumerable<BeerListingServiceModel> BeersByCountry(int countryId, int page = DefaultPage, int pageSize = DefaultPageSize)
            => this.db.Beers
                .Where(b => b.Brewery.CountryId == countryId)
                .OrderBy(b => b.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BeerListingServiceModel>()
                .ToList();

        public IEnumerable<BeerListingServiceModel> BeersByStyle(int styleId, int page = DefaultPage, int pageSize = DefaultPageSize)
            => this.db.Beers
                .Where(b => b.StyleId == styleId)
                .OrderBy(b => b.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BeerListingServiceModel>()
                .ToList();

        public IEnumerable<BeerListingServiceModel> BeersByColor(BeerColor color, int page = DefaultPage, int pageSize = DefaultPageSize)
            => this.db.Beers
                .Where(b => b.Color == color)
                .OrderBy(b => b.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BeerListingServiceModel>()
                .ToList();

        public IEnumerable<BeerListingServiceModel> Search(string searchTerm)
        {
            searchTerm = searchTerm ?? string.Empty;
            return this.db.Beers
                   .Where(b => b.Name.ToLower().Contains(searchTerm.ToLower()))
                   .ProjectTo<BeerListingServiceModel>()
                   .ToList();
        }

        public IDictionary<BeerColor, int> ColorsWithBeersCount()
            => this.db.Beers
                .GroupBy(b => b.Color)
                .ToDictionary(b => b.Key, b => b.Count());

        public BeerDetailsServiceModel ById(int id)
            => this.db.Beers
                .Where(b => b.Id == id)
                .ProjectTo<BeerDetailsServiceModel>()
                .FirstOrDefault();

        public int Total()
            => this.db.Beers.Count();

        public int TotalByCountry(int countryId)
            => this.db.Beers
                .Where(b => b.Brewery.CountryId == countryId)
                .Count();

        public int TotalByStyle(int styleId)
            => this.db.Beers
                .Where(b => b.StyleId == styleId)
                .Count();

        public int TotalByColor(BeerColor color)
            => this.db.Beers
                .Where(b => b.Color == color)
                .Count();

        public bool Exists(int id)
            => this.db.Beers.Any(b => b.Id == id);
    }
}

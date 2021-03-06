﻿namespace BeerShop.Services.Shopping.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models.GiftSets;
    using System.Collections.Generic;
    using System.Linq;

    using static ServiceConstants;

    public class ShoppingGiftSetService : IShoppingGiftSetService
    {
        private readonly BeerShopDbContext db;

        public ShoppingGiftSetService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<GiftSetListingServiceModel> LatestListing()
            => this.db.GiftSets
                .OrderByDescending(gs => gs.Id)
                .Take(ListingNumber)
                .ProjectTo<GiftSetListingServiceModel>()
                .ToList();

        public IEnumerable<GiftSetListingServiceModel> All(int page = DefaultPage, int pageSize = DefaultPageSize)
            => this.db.GiftSets
                .OrderBy(gs => gs.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<GiftSetListingServiceModel>()
                .ToList();

        public IEnumerable<GiftSetListingServiceModel> Search(string searchTerm)
        {
            searchTerm = searchTerm ?? string.Empty;
            return this.db.GiftSets
                   .OrderByDescending(gs => gs.Id)
                   .Where(gs => gs.Name.ToLower().Contains(searchTerm.ToLower()))
                   .ProjectTo<GiftSetListingServiceModel>()
                   .ToList();
        }

        public IEnumerable<GiftSetOrderServiceModel> ByIds(IDictionary<int, int> ids)
        {
            var giftSets = new List<GiftSetOrderServiceModel>();

            foreach (var id in ids)
            {
                var giftSet = this.db.GiftSets
                         .Where(gs => gs.Id == id.Key && id.Value > 0)
                         .ProjectTo<GiftSetOrderServiceModel>(new { quantity = id.Value })
                         .FirstOrDefault();

                if (giftSet != null)
                {
                    giftSets.Add(giftSet);
                }
            }

            return giftSets;
        }

        public GiftSetDetailsServiceModel ById(int id)
            => this.db.GiftSets
                .Where(gs => gs.Id == id)
                .ProjectTo<GiftSetDetailsServiceModel>()
                .FirstOrDefault();

        public int Total()
            => this.db.GiftSets.Count();

        public bool Exists(int id)
            => this.db.GiftSets.Any(gs => gs.Id == id);
    }
}

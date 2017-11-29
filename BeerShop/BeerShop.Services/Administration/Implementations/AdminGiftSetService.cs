namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Models.Products;
    using Data;
    using Models.GiftSets;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminGiftSetService : IAdminGiftSetService
    {
        private readonly BeerShopDbContext db;

        public AdminGiftSetService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<GiftSetListingServiceModel> AllListing()
            => this.db.GiftSets
                .OrderByDescending(gs => gs.Id)
                .ProjectTo<GiftSetListingServiceModel>()
                .ToList();

        public void Create(string name, string description, int quantity, decimal price)
        {
            var giftSet = new GiftSet
            {
                Name = name,
                Description = description,
                Quantity = quantity,
                Price = price
            };

            this.db.GiftSets.Add(giftSet);
            this.db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var giftSet = this.db.GiftSets.Find(id);

            if (giftSet == null)
            {
                return false;    
            }

            this.db.Remove(giftSet);
            this.db.SaveChanges();

            return true;
        }

        public bool Edit(int id, string name, string description, int quantity, decimal price)
        {
            var giftSet = this.db.GiftSets.Find(id);

            if (giftSet == null)
            {
                return false;
            }

            giftSet.Name = name;
            giftSet.Description = description;
            giftSet.Quantity = quantity;
            giftSet.Price = price;

            this.db.SaveChanges();

            return true;
        }
    }
}

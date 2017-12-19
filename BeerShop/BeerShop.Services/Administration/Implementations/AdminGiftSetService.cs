namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Models.Products;
    using Data;
    using Models.GiftSets;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class AdminGiftSetService : IAdminGiftSetService
    {
        private const string GiftSetsImagesPath = "wwwroot/images/giftsets";

        private readonly BeerShopDbContext db;

        public AdminGiftSetService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<GiftSetListingServiceModel> AllListing(int page = ServiceConstants.DefaultPage, int pageSize = ServiceConstants.DefaultPageSize)
            => this.db.GiftSets
                .OrderByDescending(gs => gs.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<GiftSetListingServiceModel>()
                .ToList();

        public int Total() => this.db.GiftSets.Count();

        public GiftSetEditServiceModel ById(int id)
            => this.db.GiftSets
                .Where(gs => gs.Id == id)
                .ProjectTo<GiftSetEditServiceModel>()
                .FirstOrDefault();

        public int Create(string name, string description, int quantity, decimal price)
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

            return giftSet.Id;
        }

        public void SetImage(int id, string image)
        {
            var giftSet = this.db.GiftSets.Find(id);
            giftSet.Image = image;

            this.db.SaveChanges();
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

        public bool Delete(int id)
        {
            var giftSet = this.db.GiftSets.Find(id);

            if (giftSet == null)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(giftSet.Image))
            {
                var filePath = Path
                .Combine(Directory.GetCurrentDirectory(), 
                GiftSetsImagesPath,
                giftSet.Image);

                File.Delete(filePath);
            }

            this.db.Remove(giftSet);
            this.db.SaveChanges();

            return true;
        }
    }
}

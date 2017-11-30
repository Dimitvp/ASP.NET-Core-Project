namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Models.Products;
    using Data;
    using Models.Accessories;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminAccessoryService : IAdminAccessoryService
    {
        private readonly BeerShopDbContext db;

        public AdminAccessoryService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AccessoryListingServiceModel> AllListing(int page = ServiceConstants.DefaultPage, int pageSize = ServiceConstants.DefaultPageSize)
            => this.db.Accessories
                .OrderByDescending(a => a.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<AccessoryListingServiceModel>()
                .ToList();

        public int Total() => this.db.Accessories.Count();

        public AccessoryEditServiceModel ById(int id)
            => this.db.Accessories
                .Where(a => a.Id == id)
                .ProjectTo<AccessoryEditServiceModel>()
                .FirstOrDefault();

        public void Create(string name, string description, int quantity, decimal price)
        {
            var accessory = new Accessory
            {
                Name = name,
                Description = description,
                Quantity = quantity,
                Price = price
            };

            this.db.Accessories.Add(accessory);
            this.db.SaveChanges();
        }

        public bool Edit(int id, string name, string description, int quantity, decimal price)
        {
            var accessory = this.db.Accessories.Find(id);

            if (accessory == null)
            {
                return false;
            }

            accessory.Name = name;
            accessory.Description = description;
            accessory.Quantity = quantity;
            accessory.Price = price;

            this.db.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var accessory = this.db.Accessories.Find(id);

            if (accessory == null)
            {
                return false;
            }

            this.db.Remove(accessory);
            this.db.SaveChanges();

            return true;
        }
    }
}

namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Models.Enums;
    using BeerShop.Models.Products;
    using Data;
    using Models.Glasses;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class AdminGlassService : IAdminGlassService
    {
        private const string GlassesImagesPath = "wwwroot/images/glasses";

        private readonly BeerShopDbContext db;

        public AdminGlassService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<GlassListingServiceModel> AllListing(string searchTerm, int page = ServiceConstants.DefaultPage, int pageSize = ServiceConstants.DefaultPageSize)
        {
            var glasses = this.db.Glasses.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                glasses = glasses.Where(g => g.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return glasses
                   .OrderByDescending(g => g.Id)
                   .Skip((page - 1) * pageSize)
                   .Take(pageSize)
                   .ProjectTo<GlassListingServiceModel>()
                   .ToList();
        }

        public int Total(string searchTerm)
        {
            var glasses = this.db.Glasses.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                glasses = glasses.Where(g => g.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return glasses.Count();
        }

        public int Create(string name, string description, int volume, Material material, int quantity, decimal price)
        {
            var glass = new Glass
            {
                Name = name,
                Description = description,
                Volume = volume,
                Material = material,
                Quantity = quantity,
                Price = price
            };

            this.db.Glasses.Add(glass);
            this.db.SaveChanges();

            return glass.Id;
        }

        public void SetImage(int id, string image)
        {
            var glass = this.db.Glasses.Find(id);
            glass.Image = image;

            this.db.SaveChanges();
        }

        public bool Edit(int id, string name, string description, int volume, Material material, int quantity, decimal price)
        {
            var glass = this.db.Glasses.Find(id);

            if (glass == null)
            {
                return false;
            }

            glass.Name = name;
            glass.Description = description;
            glass.Volume = volume;
            glass.Material = material;
            glass.Quantity = quantity;
            glass.Price = price;

            this.db.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var glass = this.db.Glasses.Find(id);

            if (glass == null)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(glass.Image))
            {
                var filePath = Path
                .Combine(Directory.GetCurrentDirectory(),
                GlassesImagesPath,
                glass.Image);

                File.Delete(filePath);
            }

            this.db.Remove(glass);
            this.db.SaveChanges();

            return true;
        }

        public GlassEditServiceModel ById(int id)
            => this.db.Glasses
                .Where(g => g.Id == id)
                .ProjectTo<GlassEditServiceModel>()
                .FirstOrDefault();
    }
}

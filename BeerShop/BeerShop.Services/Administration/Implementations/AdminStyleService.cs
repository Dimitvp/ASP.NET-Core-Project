namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Models;
    using Data;
    using Models.Styles;
    using System.Collections.Generic;
    using System.Linq;

    using static ServiceConstants;

    public class AdminStyleService : IAdminStyleService
    {
        private readonly BeerShopDbContext db;

        public AdminStyleService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<StyleListingServiceModel> AllListing(int page = DefaultPage, int pageSize = DefaultPageSize)
            => this.db.Styles
                .OrderBy(s => s.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<StyleListingServiceModel>()
                .ToList();

        public IEnumerable<StyleSelectServiceModel> AllForSelect()
            => this.db.Styles
                .OrderBy(s => s.Name)
                .ProjectTo<StyleSelectServiceModel>()
                .ToList();

        public void Create(string name)
        {
            var style = new Style
            {
                Name = name,
            };

            this.db.Styles.Add(style);
            this.db.SaveChanges();
        }

        public StyleEditServiceModel ById(int id)
            => this.db.Styles
                .Where(s => s.Id == id)
                .ProjectTo<StyleEditServiceModel>()
                .FirstOrDefault();

        public bool Edit(int id, string name)
        {
            var style = this.db.Styles.Find(id);

            if (style == null)
            {
                return false;
            }

            style.Name = name;

            this.db.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var style = this.db.Styles.Find(id);

            if (style == null)
            {
                return false;
            }

            this.db.Styles.Remove(style);
            this.db.SaveChanges();

            return true;
        }

        public int Total()
            => this.db.Styles.Count();
    }
}

namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Data;
    using BeerShop.Models;
    using Models.Styles;
    using System.Collections.Generic;
    using System.Linq;

    public class StyleService : IStyleService
    {
        private readonly BeerShopDbContext db;

        public StyleService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<StyleListingModel> AllListing()
            => this.db.Styles
                .OrderBy(s => s.Name)
                .ProjectTo<StyleListingModel>()
                .ToList();

        public IEnumerable<StyleSelectModel> AllForSelect()
            => this.db.Styles
                .OrderBy(s => s.Name)
                .ProjectTo<StyleSelectModel>()
                .ToList();

        public void Create(string name, string servingTemp)
        {
            var style = new Style
            {
                Name = name,
                ServingTemp = servingTemp
            };

            this.db.Styles.Add(style);
            this.db.SaveChanges();
        }

        public StyleEditModel ById(int id)
            => this.db.Styles
                .Where(s => s.Id == id)
                .ProjectTo<StyleEditModel>()
                .FirstOrDefault();

        public void Edit(int id, string name, string servingTemp)
        {
            var style = this.db.Styles.Find(id);

            if (style == null)
            {
                return;
            }

            style.Name = name;
            style.ServingTemp = servingTemp;

            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var style = this.db.Styles.Find(id);

            if (style == null)
            {
                return;
            }

            this.db.Styles.Remove(style);
            this.db.SaveChanges();
        }
    }
}

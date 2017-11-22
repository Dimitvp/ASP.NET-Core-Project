namespace BeerShop.Services.Implementations
{
    using BeerShop.Data;
    using BeerShop.Models;
    using BeerShop.Services.Models.Styles;
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
                .Select(s => new StyleListingModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    ServingTemp = s.ServingTemp
                })
                .ToList();

        public IEnumerable<StyleSelectModel> AllForSelect()
            => this.db.Styles
                .OrderBy(s=> s.Name)
                .Select(s => new StyleSelectModel
                {
                    Id = s.Id,
                    Name = s.Name
                })
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
                .Select(s => new StyleEditModel
                {
                    Name = s.Name,
                    ServingTemp = s.ServingTemp
                })
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

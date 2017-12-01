namespace BeerShop.Services.Shopping.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models.Styles;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingStyleService : IShoppingStyleService
    {
        private readonly BeerShopDbContext db;

        public ShoppingStyleService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<StyleWithBeersServiceModel> StylesWithBeersCount()
            => this.db.Styles
                .OrderBy(s => s.Name)
                .ProjectTo<StyleWithBeersServiceModel>()
                .ToList();
    }
}

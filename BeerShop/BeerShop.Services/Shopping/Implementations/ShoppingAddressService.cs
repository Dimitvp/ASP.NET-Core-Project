namespace BeerShop.Services.Shopping.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models.Addresses;
    using System.Linq;

    public class ShoppingAddressService : IShoppingAddressService
    {
        private readonly BeerShopDbContext db;

        public ShoppingAddressService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public AddressDetailsServiceModel ById(int id)
            => this.db.Addresses
                .Where(a => a.Id == id)
                .ProjectTo<AddressDetailsServiceModel>()
                .FirstOrDefault();
    }
}

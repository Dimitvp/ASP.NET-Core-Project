namespace BeerShop.Services.Shopping.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models.Users;
    using System.Linq;

    public class ShoppingUserService : IShoppingUserService
    {
        private readonly BeerShopDbContext db;

        public ShoppingUserService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public UserAddressServiceModel GetAddress(string userId)
            => this.db.Users
                .Where(u => u.Id == userId)
                .Select(u => u.Address)
                .ProjectTo<UserAddressServiceModel>()
                .FirstOrDefault();
    }
}

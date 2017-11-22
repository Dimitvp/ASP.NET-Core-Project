using BeerShop.Data;

namespace BeerShop.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly BeerShopDbContext db;

        public UserService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public void SetLoginTime()
        {
            throw new System.NotImplementedException();
        }
    }
}

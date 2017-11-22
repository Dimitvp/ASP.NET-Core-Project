namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Data;
    using Models.Admins;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminService : IAdminService
    {
        private readonly BeerShopDbContext db;

        public AdminService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<UserListingModel> AllUsers()
            => this.db.Users
                .ProjectTo<UserListingModel>()
                .ToList();

        public UserDetailsModel UserById(string id)
            => this.db.Users
                .Where(u => u.Id == id)
                .ProjectTo<UserDetailsModel>()
                .FirstOrDefault();
    }
}

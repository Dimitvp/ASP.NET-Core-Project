namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models.Admins;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminUserService : IAdminUserService
    {
        private readonly BeerShopDbContext db;

        public AdminUserService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<UserListingServiceModel> AllUsers(string searchTerm, int page, int PageSize)
        {
            var users = this.db.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                users = users
                    .Where(u => u.UserName.ToLower().Contains(searchTerm.ToLower()));
            }

            return users
                  .OrderBy(u => u.UserName)
                  .Skip((page - 1) * PageSize)
                  .Take(PageSize)
                  .ProjectTo<UserListingServiceModel>()
                  .ToList();
        }

        public int Total(string searchTerm)
        {
            var users = this.db.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                users = users
                    .Where(u => u.UserName.ToLower().Contains(searchTerm.ToLower()));
            }

            return users.Count();
        }

        public UserDetailsServiceModel UserById(string id)
            => this.db.Users
                .Where(u => u.Id == id)
                .ProjectTo<UserDetailsServiceModel>()
                .FirstOrDefault();
    }
}

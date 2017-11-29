namespace BeerShop.Services.Administration
{
    using Models.Admins;
    using System.Collections.Generic;

    public interface IAdminUserService
    {
        IEnumerable<UserListingServiceModel> AllUsers(string searchTerm, int page = ServiceConstants.DefaultPage, int pageSize = ServiceConstants.DefaultPageSize);

        int Total(string searchTerm);

        UserDetailsServiceModel UserById(string id);
    }
}

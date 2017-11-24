namespace BeerShop.Services.Administration
{
    using Models.Admins;
    using System.Collections.Generic;

    public interface IAdminUserService
    {
        IEnumerable<UserListingModel> AllUsers();

        UserDetailsModel UserById(string id);
    }
}

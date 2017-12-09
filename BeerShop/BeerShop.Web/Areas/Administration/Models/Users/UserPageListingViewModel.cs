namespace BeerShop.Web.Areas.Administration.Models.Users
{
    using Services.Administration.Models.Admins;
    using System.Collections.Generic;

    public class UserPageListingViewModel : Pager
    {
        public IEnumerable<UserListingServiceModel> Users { get; set; }

        public string SearchTerm { get; set; }
    }
}

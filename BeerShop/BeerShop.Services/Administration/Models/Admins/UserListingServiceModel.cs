namespace BeerShop.Services.Administration.Models.Admins
{
    using BeerShop.Common.Mapping;
    using BeerShop.Models;

    public class UserListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}

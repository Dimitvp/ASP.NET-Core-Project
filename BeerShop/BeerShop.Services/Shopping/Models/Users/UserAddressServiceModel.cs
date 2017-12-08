namespace BeerShop.Services.Shopping.Models.Users
{
    using BeerShop.Models;
    using Common.Mapping;

    public class UserAddressServiceModel : IMapFrom<Address>
    {
        public int Id { get; set; }

        public string Town { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }
    }
}

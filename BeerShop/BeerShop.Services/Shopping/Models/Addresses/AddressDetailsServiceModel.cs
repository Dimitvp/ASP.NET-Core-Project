namespace BeerShop.Services.Shopping.Models.Addresses
{
    using BeerShop.Models;
    using Common.Mapping;

    public class AddressDetailsServiceModel : IMapFrom<Address>
    {
        public int Id { get; set; }

        public string Town { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }
    }
}

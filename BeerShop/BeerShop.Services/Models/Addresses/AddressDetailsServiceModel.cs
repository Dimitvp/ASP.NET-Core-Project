namespace BeerShop.Services.Models.Addresses
{
    using Common.Mapping;
    using BeerShop.Models;

    public class AddressDetailsServiceModel : IMapFrom<Address>
    {
        public int Id { get; set; }
        
        public string Town { get; set; }
        
        public string Street { get; set; }
        
        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }
    }
}

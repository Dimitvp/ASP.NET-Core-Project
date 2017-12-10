namespace BeerShop.Services
{
    using Models.Addresses;

    public interface IAddressService
    {
        AddressDetailsServiceModel ById(int id);

        bool Update(int id, string town, string street, string zipCode, string phoneNumber);
    }
}

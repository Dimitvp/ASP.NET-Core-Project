namespace BeerShop.Services.Shopping
{
    using BeerShop.Services.Shopping.Models.Addresses;

    public interface IShoppingAddressService
    {
        AddressDetailsServiceModel ById(int id);

        bool Exists(int id, string town, string street, string zipcode, string phoneNumber);

        int Create(string town, string street, string zipCode, string phoneNumber);
    }
}

namespace BeerShop.Services.Shopping
{
    using BeerShop.Services.Shopping.Models.Addresses;

    public interface IShoppingAddressService
    {
        AddressDetailsServiceModel ById(int id);
    }
}

namespace BeerShop.Services.Shopping
{
    using Models.Users;

    public interface IShoppingUserService
    {
        UserAddressServiceModel GetAddress(string userId);
    }
}

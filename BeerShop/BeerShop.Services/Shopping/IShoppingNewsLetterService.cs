namespace BeerShop.Services.Shopping
{
    public interface IShoppingNewsLetterService
    {
        bool Create(string email);

        bool Exists(string email);
    }
}

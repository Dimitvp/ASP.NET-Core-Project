namespace BeerShop.Services.Shopping
{
    using Models.Styles;
    using System.Collections.Generic;

    public interface IShoppingStyleService
    {
        IEnumerable<StyleWithBeersServiceModel> StylesWithBeersCount();
    }
}

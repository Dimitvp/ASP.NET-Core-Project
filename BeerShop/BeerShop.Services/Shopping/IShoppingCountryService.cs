namespace BeerShop.Services.Shopping
{
    using Models.Countries;
    using System.Collections.Generic;

    public interface IShoppingCountryService
    {
        IEnumerable<CountryWithBeersServiceModel> CountriesWithBeersCount();
    }
}

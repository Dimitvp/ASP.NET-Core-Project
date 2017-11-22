namespace BeerShop.Services
{
    using BeerShop.Models.Enums;
    using BeerShop.Services.Models.Countries;
    using System.Collections.Generic;

    public interface ICountryService
    {
        IEnumerable<CountryListingModel> All();

        void Create(string name, Continent continent);
    }
}

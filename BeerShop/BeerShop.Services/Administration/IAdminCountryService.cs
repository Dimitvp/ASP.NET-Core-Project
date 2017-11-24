namespace BeerShop.Services.Administration
{
    using BeerShop.Models.Enums;
    using Models.Countries;
    using System.Collections.Generic;

    public interface IAdminCountryService
    {
        IEnumerable<CountryListingModel> All();

        void Create(string name, Continent continent);
    }
}

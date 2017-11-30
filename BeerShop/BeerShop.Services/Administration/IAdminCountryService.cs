namespace BeerShop.Services.Administration
{
    using BeerShop.Models.Enums;
    using Models.Countries;
    using System.Collections.Generic;

    public interface IAdminCountryService
    {
        IEnumerable<CountryListingServiceModel> All();

        IEnumerable<CountrySelectServiceModel> AllForSelect();

        void Create(string name, Continent continent);
    }
}

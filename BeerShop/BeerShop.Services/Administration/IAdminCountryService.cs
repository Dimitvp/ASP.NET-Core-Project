namespace BeerShop.Services.Administration
{
    using BeerShop.Models.Enums;
    using Models.Countries;
    using System.Collections.Generic;

    using static ServiceConstants;

    public interface IAdminCountryService
    {
        IEnumerable<CountryListingServiceModel> AllListing(int page = DefaultPage, int pageSize = DefaultPageSize);

        IEnumerable<CountrySelectServiceModel> AllForSelect();

        void Create(string name, Continent continent);

        CountryListingServiceModel ById(int id);

        bool Delete(int id);

        int Total();

    }
}

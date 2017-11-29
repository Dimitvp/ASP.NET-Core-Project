namespace BeerShop.Services.Administration
{
    using Models.Towns;
    using System.Collections.Generic;

    public interface IAdminTownService
    {
        void Create(string name, string zipcode, int countryId);

        IEnumerable<TownListingServiceModel> AllListing();

        TownEditServiceModel ById(int id);

        bool Edit(int id, string name, string zipCode, int countryId);

        bool Delete(int id);

        IEnumerable<TownSelectServiceModel> AllForSelect();
    }
}

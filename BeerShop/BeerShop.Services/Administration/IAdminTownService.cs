namespace BeerShop.Services.Administration
{
    using Models.Towns;
    using System.Collections.Generic;

    public interface IAdminTownService
    {
        void Create(string name, string zipcode, int countryId);

        IEnumerable<TownListingModel> AllListing();

        TownEditModel ById(int id);

        void Edit(int id, string name, string zipCode, int countryId);

        void Delete(int id);

        IEnumerable<TownSelectModel> AllForSelect();
    }
}

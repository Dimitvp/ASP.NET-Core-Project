namespace BeerShop.Services.Administration
{

    using Models.Breweries;
    using System.Collections.Generic;

    public interface IAdminBreweryService
    {
        IEnumerable<BreweryListingModel> AllListing(int page = 1, int pageSize = 10);

        IEnumerable<BrewerySelectModel> AllForSelect();

        void Create(string name, string address, int townId);

        int Total();

        BreweryEditModel ById(int id);

        void Edit(int id, string name, string adress, int townId);
    }
}

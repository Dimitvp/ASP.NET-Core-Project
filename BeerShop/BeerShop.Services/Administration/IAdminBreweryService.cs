namespace BeerShop.Services.Administration
{

    using Models.Breweries;
    using System.Collections.Generic;

    public interface IAdminBreweryService
    {
        IEnumerable<BreweryListingServiceModel> AllListing(int page = ServiceConstants.DefaultPage, int pageSize = ServiceConstants.DefaultPageSize);

        IEnumerable<BrewerySelectServiceModel> AllForSelect();

        void Create(string name, string address, int townId);

        int Total();

        BreweryEditServiceModel ById(int id);

        bool Edit(int id, string name, string adress, int townId);

        bool Delete(int id);
    }
}

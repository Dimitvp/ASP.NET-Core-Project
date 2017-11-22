namespace BeerShop.Services
{
    using BeerShop.Services.Models.Towns;
    using System.Collections.Generic;

    public interface ITownService
    {
        void Create(string name, string zipcode, int countryId);

        IEnumerable<TownListingModel> AllListing();

        TownEditModel ById(int id);

        void Edit(int id, string name, string zipCode, int countryId);

        void Delete(int id);
    }
}

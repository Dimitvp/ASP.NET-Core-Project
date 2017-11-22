namespace BeerShop.Services
{
    using BeerShop.Services.Models.Beers;
    using System.Collections.Generic;

    public interface IBeerService
    {
        IEnumerable<BeerListingModel> AllListing();

        void Create(string name, decimal price, int quantity, string description, int styleId, int breweryId);

        BeerEditModel ById(int id);

        void Edit(int id, string name, decimal price, int quantity, int styleId, int breweryId);

        void Delete(int id);
    }
}

namespace BeerShop.Services.Administration
{
    using Microsoft.AspNetCore.Http;
    using Models.Beers;
    using System.Collections.Generic;

    public interface IAdminBeerService
    {
        IEnumerable<BeerListingModel> AllListing(string searchTerm, int page = 1, int pageSize = 10);

        int Total(string searchTerm);

        void Create(
            string name, 
            decimal price, 
            int quantity, 
            string description, 
            int styleId, 
            int breweryId,
            IFormFile image);

        BeerEditModel ById(int id);

        void Edit(
            int id, 
            string name, 
            decimal price, 
            int quantity,
            int styleId, 
            int breweryId,
            IFormFile image);

        void Delete(int id);
    }
}

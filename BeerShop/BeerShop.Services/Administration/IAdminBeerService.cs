namespace BeerShop.Services.Administration
{
    using BeerShop.Models.Enums;
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
            double alcohol,
            string servingTemp,
            BeerColor color,
            int bitterness,
            int density,
            int sweetness,
            int gasification,
            int styleId, 
            int breweryId);

        BeerEditModel ById(int id);

        void Edit(
            int id,
            string name,
            decimal price,
            int quantity,
            string description,
            double alcohol,
            string servingTemp,
            BeerColor color,
            int bitterness,
            int density,
            int sweetness,
            int gasification,
            int styleId,
            int breweryId);

        void Delete(int id);
    }
}

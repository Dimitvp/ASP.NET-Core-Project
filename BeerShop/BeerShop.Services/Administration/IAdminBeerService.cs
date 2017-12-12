namespace BeerShop.Services.Administration
{
    using BeerShop.Models.Enums;
    using Models.Beers;
    using System.Collections.Generic;

    public interface IAdminBeerService
    {
        IEnumerable<BeerListingServiceModel> AllListing(string searchTerm, int page = ServiceConstants.DefaultPage, int pageSize = ServiceConstants.DefaultPageSize);

        int Total(string searchTerm);

        int Create(
            string name, 
            decimal price, 
            int quantity, 
            string description,
            double alcohol,
            int volume,
            string servingTemp,
            BeerColor color,
            int bitterness,
            int density,
            int sweetness,
            int gasification,
            int styleId, 
            int breweryId);

        void SetImage(int id, string image);

        BeerEditServiceModel ById(int id);

        bool Edit(
            int id,
            string name,
            decimal price,
            int quantity,
            string description,
            double alcohol,
            int volume,
            string servingTemp,
            BeerColor color,
            int bitterness,
            int density,
            int sweetness,
            int gasification,
            int styleId,
            int breweryId);

        bool Delete(int id);

        string GetName(int id);
    }
}

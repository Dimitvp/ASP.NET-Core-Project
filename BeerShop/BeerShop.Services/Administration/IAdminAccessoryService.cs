namespace BeerShop.Services.Administration
{
    using Models.Accessories;
    using System.Collections.Generic;

    public interface IAdminAccessoryService
    {
        IEnumerable<AccessoryListingServiceModel> AllListing(int page = ServiceConstants.DefaultPage, int pageSize = ServiceConstants.DefaultPageSize);

        int Total();

        AccessoryEditServiceModel ById(int id);

        void Create(string name, string description, int quantity, decimal price, string image);

        bool Edit(int id, string name, string description, int quantity, decimal price, string image);

        bool Delete(int id);

    }
}

namespace BeerShop.Services.Administration
{
    using Models.GiftSets;
    using System.Collections.Generic;

    public interface IAdminGiftSetService
    {
        IEnumerable<GiftSetListingServiceModel> AllListing(int page = ServiceConstants.DefaultPage, int pageSize = ServiceConstants.DefaultPageSize);

        int Total();

        GiftSetEditServiceModel ById(int id);

        void Create(string name, string description, int quantity, decimal price, string image);

        bool Edit(int id, string name, string description, int quantity, decimal price, string image);

        bool Delete(int id);
    }
}

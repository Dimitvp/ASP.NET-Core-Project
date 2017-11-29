namespace BeerShop.Services.Administration
{
    using Models.GiftSets;
    using System.Collections.Generic;

    public interface IAdminGiftSetService
    {
        IEnumerable<GiftSetListingServiceModel> AllListing();

        void Create(string name, string description, int quantity, decimal price);

        bool Edit(int id, string name, string description, int quantity, decimal price);

        bool Delete(int id);
    }
}

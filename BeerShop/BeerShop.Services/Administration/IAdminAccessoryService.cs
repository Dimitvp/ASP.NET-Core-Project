using BeerShop.Services.Administration.Models.Accessories;
using System.Collections.Generic;

namespace BeerShop.Services.Administration
{
    public interface IAdminAccessoryService
    {
        IEnumerable<AccessoryListingServiceModel> AllListing();

        void Create(string name, string description, int quantity, decimal price);

        bool Edit(int id, string name, string description, int quantity, decimal price);

        bool Delete(int id);
    }
}

namespace BeerShop.Services.Administration
{
    using BeerShop.Models.Enums;
    using Models.Glasses;
    using System.Collections.Generic;

    public interface IAdminGlassService
    {
        IEnumerable<GlassListingServiceModel> AllListing(string searchTerm, int page = ServiceConstants.DefaultPage, int pageSize = ServiceConstants.DefaultPageSize);

        int Total(string searchTerm);

        void Create(string name, string description, int volume, Material material, int quantity, decimal price, string image);

        bool Edit(int id, string name, string description, int volume, Material material, int quantity, decimal price, string image);

        bool Delete(int id);

        GlassEditServiceModel ById(int id);
    }
}

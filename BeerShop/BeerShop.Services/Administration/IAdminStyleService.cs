namespace BeerShop.Services.Administration
{
    using Models.Styles;
    using System.Collections.Generic;

    public interface IAdminStyleService
    {
        IEnumerable<StyleListingServiceModel> AllListing();

        IEnumerable<StyleSelectServiceModel> AllForSelect();

        void Create(string name);

        StyleEditServiceModel ById(int id);

        bool Edit(int id, string name);

        bool Delete(int id);
    }
}

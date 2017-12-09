namespace BeerShop.Services.Administration
{
    using Models.Styles;
    using System.Collections.Generic;

    using static ServiceConstants;

    public interface IAdminStyleService
    {
        IEnumerable<StyleListingServiceModel> AllListing(int page = DefaultPage, int pageSize = DefaultPageSize);

        IEnumerable<StyleSelectServiceModel> AllForSelect();

        void Create(string name);

        StyleEditServiceModel ById(int id);

        bool Edit(int id, string name);

        bool Delete(int id);

        int Total();
    }
}

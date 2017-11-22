namespace BeerShop.Services
{
    using BeerShop.Services.Models.Styles;
    using System.Collections.Generic;

    public interface IStyleService
    {
        IEnumerable<StyleListingModel> AllListing();

        IEnumerable<StyleSelectModel> AllForSelect();

        void Create(string name, string servingTemp);

        StyleEditModel ById(int id);

        void Edit(int id, string name, string servingTemp);

        void Delete(int id);

    }
}

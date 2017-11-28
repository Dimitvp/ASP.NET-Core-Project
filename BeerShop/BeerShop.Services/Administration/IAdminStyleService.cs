﻿namespace BeerShop.Services.Administration
{
    using Models.Styles;
    using System.Collections.Generic;

    public interface IAdminStyleService
    {
        IEnumerable<StyleListingModel> AllListing();

        IEnumerable<StyleSelectModel> AllForSelect();

        void Create(string name);

        StyleEditModel ById(int id);

        void Edit(int id, string name);

        void Delete(int id);
    }
}

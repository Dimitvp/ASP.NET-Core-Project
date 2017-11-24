namespace BeerShop.Services.Administration
{

    using Models.Breweries;
    using System.Collections.Generic;

    public interface IAdminBreweryService
    {
        IEnumerable<BrewerySelectModel> AllForSelect();
    }
}

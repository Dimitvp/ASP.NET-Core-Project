namespace BeerShop.Services.Administration
{

    using Models.Breweries;
    using System.Collections.Generic;

    public interface IBreweryService
    {
        IEnumerable<BrewerySelectModel> AllForSelect();
    }
}

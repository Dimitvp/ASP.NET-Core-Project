namespace BeerShop.Services
{
    using BeerShop.Services.Models.Breweries;
    using System.Collections.Generic;

    public interface IBreweryService
    {
        IEnumerable<BrewerySelectModel> AllForSelect();
    }
}

namespace BeerShop.Web.Areas.Administration.Models.Breweries
{
    using Services.Administration.Models.Breweries;
    using System.Collections.Generic;

    public class BreweryPageListingViewModel : Pager
    {
        public IEnumerable<BreweryListingServiceModel> Breweries { get; set; }
    }
}
namespace BeerShop.Web.Areas.Administration.Models.Beers
{
    using BeerShop.Services.Administration.Models.Beers;
    using System.Collections.Generic;

    public class BeerPageListingViewModel : Pager
    {
        public IEnumerable<BeerListingServiceModel> Beers { get; set; }

        public string SearchTerm { get; set; }
    }
}

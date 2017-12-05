namespace BeerShop.Web.Areas.Shopping.Models.Beers
{
    using Services.Shopping.Models.Beers;
    using System.Collections.Generic;

    public class BeerListingViewModel : Pager
    {
        public IEnumerable<BeerListingServiceModel> Beers { get; set; }
    }
}

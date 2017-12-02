namespace BeerShop.Web.Areas.Shopping.Models.Beers
{
    using BeerShop.Models.Enums;
    using Services.Shopping.Models.Beers;
    using System.Collections.Generic;

    public class BeersByColorPageListingViewModel : Pager
    {
        public IEnumerable<BeerListingServiceModel> Beers { get; set; }
        
        public BeerColor Color { get; set; }
    }
}

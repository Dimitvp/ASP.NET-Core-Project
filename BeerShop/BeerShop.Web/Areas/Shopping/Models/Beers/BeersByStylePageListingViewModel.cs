namespace BeerShop.Web.Areas.Shopping.Models.Beers
{
    using Services.Shopping.Models.Beers;
    using System.Collections.Generic;

    public class BeersByStylePageListingViewModel : Pager
    {
        public IEnumerable<BeerListingServiceModel> Beers { get; set; }

        public string Style { get; set; }

        public int StyleId { get; set; }
    }
}

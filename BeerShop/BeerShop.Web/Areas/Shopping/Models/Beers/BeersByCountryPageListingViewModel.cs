namespace BeerShop.Web.Areas.Shopping.Models.Beers
{
    using Services.Shopping.Models.Beers;
    using System.Collections.Generic;

    public class BeersByCountryPageListingViewModel : Pager
    {
        public IEnumerable<BeerListingServiceModel> Beers { get; set; }

        public string Country { get; set; }

        public int CountryId { get; set; }
    }
}

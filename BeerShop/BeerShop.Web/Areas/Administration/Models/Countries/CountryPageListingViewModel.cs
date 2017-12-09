namespace BeerShop.Web.Areas.Administration.Models.Countries
{
    using Services.Administration.Models.Countries;
    using System.Collections.Generic;

    public class CountryPageListingViewModel : Pager
    {
        public IEnumerable<CountryListingServiceModel> Countries { get; set; }
    }
}

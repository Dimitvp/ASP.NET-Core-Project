namespace BeerShop.Web.Areas.Shopping.Models.Beers
{
    using Services.Shopping.Models.Beers;
    using System.Collections.Generic;

    public class BeersByCountryPageListingViewModel
    {
        public IEnumerable<BeerListingServiceModel> Beers { get; set; }

        public string Country { get; set; }

        public int CountryId { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PreviousPage => this.CurrentPage == 1
            ? 1
            : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages
            ? this.TotalPages
            : this.CurrentPage + 1;
    }
}

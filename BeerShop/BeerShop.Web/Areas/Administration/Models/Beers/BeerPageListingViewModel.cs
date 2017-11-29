namespace BeerShop.Web.Areas.Administration.Models.Beers
{
    using BeerShop.Services.Administration.Models.Beers;
    using System.Collections.Generic;

    public class BeerPageListingViewModel
    {
        public IEnumerable<BeerListingServiceModel> Beers { get; set; }

        public string SearchTerm { get; set; }

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

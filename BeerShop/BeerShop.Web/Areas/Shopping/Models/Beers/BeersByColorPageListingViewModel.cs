namespace BeerShop.Web.Areas.Shopping.Models.Beers
{
    using BeerShop.Models.Enums;
    using Services.Shopping.Models.Beers;
    using System.Collections.Generic;

    public class BeersByColorPageListingViewModel
    {
        public IEnumerable<BeerListingServiceModel> Beers { get; set; }
        
        public BeerColor Color { get; set; }

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

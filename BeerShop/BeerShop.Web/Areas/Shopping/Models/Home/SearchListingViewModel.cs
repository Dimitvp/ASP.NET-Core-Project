namespace BeerShop.Web.Areas.Shopping.Models.Home
{
    using Services.Shopping.Models.Accessories;
    using Services.Shopping.Models.Beers;
    using Services.Shopping.Models.GiftSets;
    using Services.Shopping.Models.Glasses;
    using System.Collections.Generic;

    public class SearchListingViewModel
    {
        public IEnumerable<AccessoryListingServiceModel> Accessories { get; set; } = new List<AccessoryListingServiceModel>();

        public IEnumerable<BeerListingServiceModel> Beers { get; set; } = new List<BeerListingServiceModel>();

        public IEnumerable<GiftSetListingServiceModel> GiftSets { get; set; } = new List<GiftSetListingServiceModel>();

        public IEnumerable<GlassListingServiceModel> Glasses { get; set; } = new List<GlassListingServiceModel>();

        public string SearchTerm { get; set; }
    }
}

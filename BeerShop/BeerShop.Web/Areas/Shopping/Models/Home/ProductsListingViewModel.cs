namespace BeerShop.Web.Areas.Shopping.Models.Home
{
    using Services.Shopping.Models.Accessories;
    using Services.Shopping.Models.Beers;
    using Services.Shopping.Models.GiftSets;
    using Services.Shopping.Models.Glasses;
    using System.Collections.Generic;

    public class ProductsListingViewModel
    {
        public IEnumerable<LatestAccessoryListingServiceModel> Accessories { get; set; }

        public IEnumerable<BeerListingServiceModel> Beers { get; set; }

        public IEnumerable<LatestGiftSetListingServiceModel> GiftSets { get; set; }

        public IEnumerable<LatestGlassListingServiceModel> Glasses { get; set; }
    }
}

namespace BeerShop.Web.Areas.Shopping.Models.GiftSets
{
    using Services.Shopping.Models.GiftSets;
    using System.Collections.Generic;

    public class GiftSetPageListingViewModel : Pager
    {
        public IEnumerable<GiftSetListingServiceModel> GiftSets { get; set; }
    }
}

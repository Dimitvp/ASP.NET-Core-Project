namespace BeerShop.Web.Areas.Administration.Models.GiftSets
{
    using Services.Administration.Models.GiftSets;
    using System.Collections.Generic;

    public class GiftSetPageListingViewModel : Pager
    {
        public IEnumerable<GiftSetListingServiceModel> GiftSets { get; set; }
    }
}

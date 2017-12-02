namespace BeerShop.Web.Areas.Shopping.Models.Glasses
{
    using Services.Shopping.Models.Glasses;
    using System.Collections.Generic;

    public class GlassPageListingViewModel : Pager
    {
        public IEnumerable<GlassListingServiceModel> Glasses { get; set; }
    }
}

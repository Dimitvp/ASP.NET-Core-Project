namespace BeerShop.Web.Areas.Administration.Models.Glasses
{
    using Services.Administration.Models.Glasses;
    using System.Collections.Generic;

    public class GlassPageListingViewModel : Pager
    {
        public IEnumerable<GlassListingServiceModel> Glasses { get; set; }

        public string SearchTerm { get; set; }
    }
}

namespace BeerShop.Web.Areas.Administration.Models.Styles
{
    using Services.Administration.Models.Styles;
    using System.Collections.Generic;

    public class StylePageListingViewModel : Pager
    {
        public IEnumerable<StyleListingServiceModel> Styles { get; set; }
    }
}

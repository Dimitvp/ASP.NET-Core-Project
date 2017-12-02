namespace BeerShop.Web.Areas.Shopping.Models.Accessories
{
    using Services.Shopping.Models.Accessories;
    using System.Collections.Generic;

    public class AccessoryPageListingViewModel : Pager
    {
        public IEnumerable<AccessoryListingServiceModel> Accessories { get; set; }
    }
}

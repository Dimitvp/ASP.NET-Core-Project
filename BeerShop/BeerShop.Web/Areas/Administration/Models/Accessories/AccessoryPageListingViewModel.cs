namespace BeerShop.Web.Areas.Administration.Models.Accessories
{
    using Services.Administration.Models.Accessories;
    using System.Collections.Generic;

    public class AccessoryPageListingViewModel : Pager
    {
        public IEnumerable<AccessoryListingServiceModel> Accessories { get; set; }
        
    }
}

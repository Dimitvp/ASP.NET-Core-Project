namespace BeerShop.Web.Areas.Administration.Models.Newsletter
{
    using Services.Administration.Models.Newsletter;
    using System.Collections.Generic;

    public class EmailPageListingViewModel : Pager
    {
        public IEnumerable<EmailListingServiceModel> Emails{ get; set; }
    }
}

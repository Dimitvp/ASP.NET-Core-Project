namespace BeerShop.Web.Areas.Administration.Models.Logs
{
    using Services.Administration.Models.Logs;
    using System.Collections.Generic;

    public class LogPageListingViewModel : Pager
    {
        public IEnumerable<LogListingServiceModel> Logs { get; set; }
    }
}

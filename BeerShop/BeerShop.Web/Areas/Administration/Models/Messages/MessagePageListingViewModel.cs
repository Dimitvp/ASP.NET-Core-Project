namespace BeerShop.Web.Areas.Administration.Models.Messages
{
    using System.Collections.Generic;
    using Services.Administration.Models.Messages;

    public class MessagePageListingViewModel : Pager
    {
        public IEnumerable<MessageListingServiceModel> Messages { get; set; }
    }
}

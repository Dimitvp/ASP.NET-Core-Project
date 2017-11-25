namespace BeerShop.Services.Administration.Models.Messages
{
    public class MessageDetailsModel : MessageListingModel
    {
        public string Phone { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }
    }
}

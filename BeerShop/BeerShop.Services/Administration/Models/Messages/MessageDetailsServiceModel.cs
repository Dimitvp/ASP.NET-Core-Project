namespace BeerShop.Services.Administration.Models.Messages
{
    public class MessageDetailsServiceModel : MessageListingServiceModel
    {
        public string Phone { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }
    }
}

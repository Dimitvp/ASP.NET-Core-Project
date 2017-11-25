namespace BeerShop.Services.Administration.Models.Messages
{
    using BeerShop.Common.Mapping;
    using BeerShop.Models;
    using System;

    public class MessageListingModel : IMapFrom<Message>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public DateTime SentOn { get; set; }

        public bool IsRead { get; set; }
    }
}

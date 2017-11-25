namespace BeerShop.Services.Implementations
{
    using BeerShop.Data;
    using BeerShop.Models;
    using System;

    public class MessageService : IMessageService
    {
        private readonly BeerShopDbContext db;

        public MessageService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string email, string phone, string subject, string content)
        {
            var messages = new Message
            {
                Name = name,
                Email = email,
                Phone = phone,
                Subject = subject,
                Content = content,
                SentOn = DateTime.UtcNow
            };

            this.db.Messages.Add(messages);
            this.db.SaveChanges();
        }
    }
}

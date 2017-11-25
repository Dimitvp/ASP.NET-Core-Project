namespace BeerShop.Services.Administration.Implementations
{
    using System.Collections.Generic;
    using Models.Messages;
    using BeerShop.Data;
    using System.Linq;
    using AutoMapper.QueryableExtensions;

    public class AdminMessageService : IAdminMessageService
    {
        private readonly BeerShopDbContext db;

        public AdminMessageService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<MessageListingModel> AllListing(int page = 1, int pageSize = 5)
            => this.db
            .Messages
            .OrderByDescending(m => m.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ProjectTo<MessageListingModel>()
            .ToList();

        public int Total()
            => this.db
            .Messages
            .Count();

        public MessageDetailsModel ById(int id)
            => this.db.Messages
            .Where(m => m.Id == id)
            .ProjectTo<MessageDetailsModel>()
            .FirstOrDefault();

        public void MarkAsRead(int id)
        {
            var message = this.db
                .Messages
                .Where(m => m.Id == id)
                .FirstOrDefault();

            if (message == null)
            {
                return;
            }

            message.IsRead = true;
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var message = this.db.Messages
                .Where(m=> m.Id == id)
                .FirstOrDefault();

            if (message == null)
            {
                return;
            }

            this.db.Messages.Remove(message);
            this.db.SaveChanges();
        }
    }
}

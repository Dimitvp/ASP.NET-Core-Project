namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models.Messages;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminMessageService : IAdminMessageService
    {
        private readonly BeerShopDbContext db;

        public AdminMessageService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<MessageListingServiceModel> AllListing(int page = ServiceConstants.DefaultPage, int pageSize = ServiceConstants.DefaultPageSize)
            => this.db
                .Messages
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<MessageListingServiceModel>()
                .ToList();

        public int Total()
            => this.db
                .Messages
                .Count();

        public MessageDetailsServiceModel ById(int id)
            => this.db.Messages
                .Where(m => m.Id == id)
                .ProjectTo<MessageDetailsServiceModel>()
                .FirstOrDefault();

        public void MarkAsRead(int id)
        {
            var message = this.db.Messages.Find(id);

            if (message == null)
            {
                return;
            }

            message.IsRead = true;
            this.db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var message = this.db.Messages.Find(id);

            if (message == null)
            {
                return false;
            }

            this.db.Messages.Remove(message);
            this.db.SaveChanges();

            return true;
        }
    }
}

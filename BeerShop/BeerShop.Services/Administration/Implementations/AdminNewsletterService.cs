namespace BeerShop.Services.Administration.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models.Newsletter;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class AdminNewsletterService : IAdminNewsletterService
    {
        private readonly BeerShopDbContext db;

        public AdminNewsletterService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<EmailListingServiceModel> All(int page = 1, int pageSize = 10)
            => this.db.Subscriptions
                .OrderByDescending(s => s.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<EmailListingServiceModel>()
                .ToList();

        public EmailListingServiceModel ById(int id)
            => this.db.Subscriptions
                .Where(s => s.Id == id)
                .ProjectTo<EmailListingServiceModel>()
                .FirstOrDefault();

        public bool Delete(int id)
        {
            var subscriber = this.db.Subscriptions.Find(id);

            if (subscriber == null)
            {
                return false;
            }

            this.db.Subscriptions.Remove(subscriber);
            this.db.SaveChanges();

            return true;
        }

        public byte[] Emails()
        {
            var emails = this.db.Subscriptions
                    .Select(s => s.Email)
                    .ToList();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (var stremWriter = new StreamWriter(memoryStream))
                {
                    stremWriter.Write(string.Join(" ", emails));
                }

                return memoryStream.ToArray();
            }
        }

        public int Total()
            => this.db.Subscriptions.Count();
    }
}

namespace BeerShop.Services.Shopping.Implementations
{
    using BeerShop.Models;
    using Data;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ShoppingNewsLetterService : IShoppingNewsLetterService
    {
        private const string EmailPattern = @"(?<=^|[\s+])([A-Za-z0-9]+[-.\w]+@([\w]+[-\w]+[.]){1,2}[a-z]+)(?=$|[,.\s+])";
        private readonly BeerShopDbContext db;

        public ShoppingNewsLetterService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public bool Create(string email)
        {
            var isEmailValid = Regex.IsMatch(email, EmailPattern);

            if (!isEmailValid)
            {
                return false;
            }

            var subscribtion = new Subscription
            {
                Email = email
            };

            this.db.Subscriptions.Add(subscribtion);
            this.db.SaveChanges();

            return true;
        }

        public bool Exists(string email)
            => this.db.Subscriptions.Any(s => s.Email.ToLower() == email.ToLower());
    }
}

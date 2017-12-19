namespace BeerShop.Tests.Services.Shopping
{
    using BeerShop.Models;
    using BeerShop.Services.Shopping.Implementations;
    using Data;
    using FluentAssertions;
    using Xunit;

    public class NewsLetterServiceTest
    {
        private const string EmailAddress = "test@test.bg";

        private BeerShopDbContext db;

        public NewsLetterServiceTest()
        {
            this.db = Tests.GetDatabase();
        }

        [Fact]
        public void IfCreateIsSuccessfulShouldReturnTrue()
        {
            // Arrange
            var addressService = new ShoppingNewsLetterService(this.db);

            // Act
            var result = addressService.Create(EmailAddress);

            // Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void IfCreateIsNotSuccessfulShouldReturnFalse()
        {
            // Arrange
            var addressService = new ShoppingNewsLetterService(this.db);
            string emailAddress = "test@test";

            // Act
            var result = addressService.Create(emailAddress);

            // Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void ExistsShouldReturnTrueIfEmailExist()
        {
            // Arrange
            var emailAddress = new Subscription
            {
                Id = 1,
                Email = EmailAddress
            };

            this.db.Subscriptions.Add(emailAddress);
            this.db.SaveChanges();

            var addressService = new ShoppingNewsLetterService(this.db);

            // Act
            var result = addressService.Exists(EmailAddress);

            // Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void ExistsShouldReturnFalseIfEmailDontExist()
        {
            // Arrange
            var addressService = new ShoppingNewsLetterService(this.db);

            // Act
            var result = addressService.Exists(EmailAddress);

            // Assert
            result
                .Should()
                .BeFalse();
        }
    }
}

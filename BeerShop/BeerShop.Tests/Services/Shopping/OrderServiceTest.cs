namespace BeerShop.Tests.Services.Shopping
{
    using BeerShop.Models;
    using BeerShop.Services.Shopping.Implementations;
    using Data;
    using FluentAssertions;
    using System.Collections.Generic;
    using Xunit;

    public class OrderServiceTest
    {

        private BeerShopDbContext db;

        public OrderServiceTest()
        {
            this.db = Tests.GetDatabase();
        }

        [Fact]
        public void CreateShouldReturnFalseIfAddressIsNotCorrect()
        {
            // Arrange
            var orderService = new ShoppingOrderService(this.db);

            // Act
            var result = orderService.Create(null, null, null, null, 0, 1, null);

            // Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void CreateShouldReturnFalseIfUserIsNotCorrect()
        {
            // Arrange
            var address = new Address
            {
                Id = 1,
                PhoneNumber = "Test",
                Street = "Test",
                Town = "Test",
                ZipCode = "Test"
            };

            this.db.Addresses.Add(address);
            this.db.SaveChanges();

            var orderService = new ShoppingOrderService(this.db);

            // Act
            var result = orderService.Create(null, null, null, null, 0, 1, "1");

            // Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void CreateShouldReturnTrueIfDataIsCorrect()
        {
            // Arrange
            var address = new Address
            {
                Id = 1,
                PhoneNumber = "Test",
                Street = "Test",
                Town = "Test",
                ZipCode = "Test"
            };

            var user = new User { Id = "test" };

            this.db.Users.Add(user);
            this.db.Addresses.Add(address);
            this.db.SaveChanges();

            var orderService = new ShoppingOrderService(this.db);

            var dictionary = new Dictionary<int, int>();    

            // Act
            var result = orderService.Create(dictionary, dictionary, dictionary, dictionary, 0, 1, "test");

            // Assert
            result
                .Should()
                .BeTrue();
        }
    }
}

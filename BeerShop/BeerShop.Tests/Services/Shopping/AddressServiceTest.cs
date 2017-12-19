namespace BeerShop.Tests.Services.Shopping
{
    using BeerShop.Data;
    using BeerShop.Models;
    using BeerShop.Services.Shopping.Implementations;
    using FluentAssertions;
    using Xunit;

    public class AddressServiceTest
    {
        private BeerShopDbContext db;

        public AddressServiceTest()
        {
            this.db = Tests.GetDatabase();
        }

        [Fact]
        public void CreateShouldReturnCorrectId()
        {
            // Arrange
            var addressService = new ShoppingAddressService(this.db);

            // Act
            var result = addressService.Create("Test", "Test", "Test", "Test");

            // Assert
            result
                .Should()
                .Equals(1);
        }

        [Fact]
        public void FindShouldReturnTrueIfExist()
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

            var addressService = new ShoppingAddressService(this.db);

            // Act
            var result = addressService.Exists(1, "Test", "Test", "Test", "Test");

            // Assert

            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void FindShouldReturnFalseIfDontExist()
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

            var addressService = new ShoppingAddressService(this.db);

            // Act
            var result = addressService.Exists(1, "Test", "Test", "Test", "TestOne");

            // Assert

            result
                .Should()
                .BeFalse();
        }
    }
}

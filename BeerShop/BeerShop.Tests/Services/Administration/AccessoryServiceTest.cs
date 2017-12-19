namespace BeerShop.Tests.Services.Administration
{
    using BeerShop.Models.Products;
    using BeerShop.Services.Administration.Implementations;
    using Data;
    using FluentAssertions;
    using Xunit;

    public class AccessoryServiceTest
    {
        private BeerShopDbContext db;

        public AccessoryServiceTest()
        {
            Tests.Initialize();
            this.db = Tests.GetDatabase();
        }

        [Fact]
        public void TotalShouldReturnCorrectCount()
        {
            // Arrange
            var firstAccessory = new Accessory { Id = 1, Name = "First" };
            var secondAccessory = new Accessory { Id = 2, Name = "Second" };
            var thirdAccessory = new Accessory { Id = 3, Name = "Third" };

            this.db.AddRange(firstAccessory, secondAccessory, thirdAccessory);
            this.db.SaveChanges();

            var accessoryService = new AdminAccessoryService(this.db);

            // Act
            var result = accessoryService.Total();

            // Assert
            result
                .Should()
                .Equals(3);
        }

        [Fact]
        public void CreateShouldReturnCorrectId()
        {
            // Arrange
            var accessoryService = new AdminAccessoryService(this.db);

            // Act
            var result = accessoryService.Create("test", "test", 1, 2m);

            // Assert
            result
                .Should()
                .Equals(1);
        }

        [Fact]
        public void EditShouldReturnTrueIfItIsSuccessfull()
        {
            // Arrange
            var accessory = new Accessory
            {
                Id = 1,
                Name = "Test"
            };

            this.db.Accessories.Add(accessory);
            this.db.SaveChanges();

            var accessoryService = new AdminAccessoryService(this.db);

            // Act
            var result = accessoryService.Edit(1, "test", "test", 1, 1m);

            // Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void EditShouldReturnFalseIfItIsNotSuccessfull()
        {
            // Arrange
            var accessory = new Accessory
            {
                Id = 1,
                Name = "Test"
            };

            this.db.Accessories.Add(accessory);
            this.db.SaveChanges();

            var accessoryService = new AdminAccessoryService(this.db);

            // Act
            var result = accessoryService.Edit(2, "test", "test", 1, 1m);

            // Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void DeleteShouldReturnTrueIfItIsSuccessfull()
        {
            // Arrange
            var accessory = new Accessory
            {
                Id = 1,
                Name = "Test"
            };

            this.db.Accessories.Add(accessory);
            this.db.SaveChanges();

            var accessoryService = new AdminAccessoryService(this.db);

            // Act
            var result = accessoryService.Delete(1);

            // Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void DeleteShouldReturnFalseIfItIsNotSuccessfull()
        {
            // Arrange
            var accessoryService = new AdminAccessoryService(this.db);

            // Act
            var result = accessoryService.Delete(1);

            // Assert
            result
                .Should()
                .BeFalse();
        }
    }
}

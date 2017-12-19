namespace BeerShop.Tests.Services.Shopping
{
    using BeerShop.Models.Products;
    using BeerShop.Services.Shopping.Implementations;
    using Data;
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
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
        public void SearchShouldReturnCorrectResultsWithFilterAndOrder()
        {
            // Arrange
            var firstAccessory = new Accessory { Id = 1, Name = "First" };
            var secondAccessory = new Accessory { Id = 2, Name = "Second" };
            var thirdAccessory = new Accessory { Id = 3, Name = "Third" };

            this.db.AddRange(firstAccessory, secondAccessory, thirdAccessory);
            this.db.SaveChanges();

            var accessoryService = new ShoppingAccessoryService(this.db);

            // Act
            var result = accessoryService.Search("r");
            var secondResult = accessoryService.Search(string.Empty);

            // Assert
            result.Should()
                .Match(r =>
                    r.ElementAt(0).Id == 3
                    && r.ElementAt(1).Id == 1)
                .And
                .HaveCount(2);

            secondResult
                .Should()
                .HaveCount(3);
        }

        [Fact]
        public void ByIdsShouldReturnCorrectIdsWithCorrectQuantity()
        {
            // Arrange
            var firstAccessory = new Accessory { Id = 1, Name = "First" };
            var thirdAccessory = new Accessory { Id = 3, Name = "Third" };

            this.db.AddRange(firstAccessory, thirdAccessory);
            this.db.SaveChanges();

            var accessoryService = new ShoppingAccessoryService(this.db);

            var idsWithQuantity = new Dictionary<int, int>()
            {
                {1,3 },
                {3,2 }
            };

            // Act
            var result = accessoryService.ByIds(idsWithQuantity);
            var secondResult = accessoryService.ByIds(new Dictionary<int,int>());

            // Assert
            result
                .Should()
                .Match(r =>
                    (r.ElementAt(0).Id == 1 && r.ElementAt(0).Quantity == 3)
                    && (r.ElementAt(1).Id == 3 && r.ElementAt(1).Quantity == 2))
                .And
                .HaveCount(2);

            secondResult
                .Should()
                .HaveCount(0);
        }

        [Fact]
        public void ExistsShouldReturnTrueIfItemExist()
        {
            //Arrange
            var firstAccessory = new Accessory { Id = 1, Name = "First" };

            this.db.Add(firstAccessory);
            this.db.SaveChanges();

            var accessoryService = new ShoppingAccessoryService(this.db);
            //Act
            var result = accessoryService.Exists(1);

            //Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void ExistsShouldReturnFalseIfItemExist()
        {
            //Arrange
            var firstAccessory = new Accessory { Id = 1, Name = "First" };

            this.db.Add(firstAccessory);
            this.db.SaveChanges();

            var accessoryService = new ShoppingAccessoryService(this.db);
            //Act
            var result = accessoryService.Exists(2);

            //Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TotalShouldReturnCorrectResult()
        {
            //Arrange
            var firstAccessory = new Accessory { Id = 1, Name = "First" };
            var secondAccessory = new Accessory { Id = 2, Name = "Second" };
            var thirdAccessory = new Accessory { Id = 3, Name = "Third" };

            this.db.AddRange(firstAccessory, secondAccessory, thirdAccessory);
            this.db.SaveChanges();

            var accessoryService = new ShoppingAccessoryService(this.db);
            //Act
            var result = accessoryService.Total();

            //Assert
            result
                .Should()
                .Equals(3);
        }
    }
}

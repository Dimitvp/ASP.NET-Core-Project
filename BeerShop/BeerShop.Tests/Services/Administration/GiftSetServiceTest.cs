using BeerShop.Data;
using BeerShop.Models.Products;
using BeerShop.Services.Administration.Implementations;
using FluentAssertions;
using Xunit;

namespace BeerShop.Tests.Services.Administration
{
    public class GiftSetServiceTest
    {
        private BeerShopDbContext db;

        public GiftSetServiceTest()
        {
            this.db = Tests.GetDatabase();
        }

        [Fact]
        public void TotalShouldReturnCorrectCount()
        {
            // Arrange
            var first = new GiftSet { Id = 1, Name = "First" };
            var second = new GiftSet { Id = 2, Name = "Second" };
            var third = new GiftSet { Id = 3, Name = "Third" };

            this.db.AddRange(first, second, third);
            this.db.SaveChanges();

            var giftSetService = new AdminGiftSetService(this.db);

            // Act
            var result = giftSetService.Total();

            // Assert
            result
                .Should()
                .Equals(3);
            
        }

        [Fact]
        public void CreateShoultReturnCorrectId()
        {
            // Arrange
            var giftSetService = new AdminGiftSetService(this.db);

            // Act
            var result = giftSetService.Create("test", "test", 1, 2);

            // Assert
            result
                .Should()
                .Equals(1);
        }

        [Fact]
        public void EditShouldReturnTrueIfItIsSuccessfull()
        {
            // Arrange
            var giftSet = new GiftSet
            {
                Id = 1,
                Name = "Test"
            };

            this.db.GiftSets.Add(giftSet);
            this.db.SaveChanges();

            var giftSetService = new AdminGiftSetService(this.db);

            // Act
            var result = giftSetService.Edit(1, "", "", 1, 2);

            // Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void EditShouldReturnFalseIfItIsNotSuccessfull()
        {
            // Arrange

            var giftSetService = new AdminGiftSetService(this.db);

            // Act
            var result = giftSetService.Edit(1, "", "", 1, 2);


            // Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void DeleteShouldReturnTrueIfItIsSuccessfull()
        {
            // Arrange
            var giftSet = new GiftSet
            {
                Id = 1,
                Name = "Test"
            };

            this.db.GiftSets.Add(giftSet);
            this.db.SaveChanges();

            var giftSetService = new AdminGiftSetService(this.db);

            // Act
            var result = giftSetService.Delete(1);

            // Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void DeleteShouldReturnFalseIfItIsNotSuccessfull()
        {
            // Arrange
            var giftSetService = new AdminGiftSetService(this.db);

            // Act
            var result = giftSetService.Delete(1);

            // Assert
            result
                .Should()
                .BeFalse();
        }
    }
}

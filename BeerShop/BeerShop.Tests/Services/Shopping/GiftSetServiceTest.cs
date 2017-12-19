namespace BeerShop.Tests.Services.Shopping
{
    using BeerShop.Models.Products;
    using BeerShop.Services.Shopping.Implementations;
    using Data;
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class GiftSetServiceTest
    {
        private BeerShopDbContext db;

        public GiftSetServiceTest()
        {
            Tests.Initialize();
            this.db = Tests.GetDatabase();
        }

        [Fact]
        public void SearchShouldReturnCorrectResultsWithFilterAndOrder()
        {
            // Arrange
            var firstGiftSet = new GiftSet { Id = 1, Name = "First" };
            var secondGiftSet = new GiftSet { Id = 2, Name = "Second" };
            var thirdGiftSet = new GiftSet { Id = 3, Name = "Third" };

            this.db.AddRange(firstGiftSet, secondGiftSet, thirdGiftSet);
            this.db.SaveChanges();

            var giftSetService = new ShoppingGiftSetService(this.db);

            // Act
            var result = giftSetService.Search("d");
            var secondResult = giftSetService.Search(string.Empty);

            // Assert
            result.Should()
                .Match(r =>
                    r.ElementAt(0).Id == 3
                    && r.ElementAt(1).Id == 2)
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
            var firstGiftSet = new GiftSet { Id = 1, Name = "First" };
            var secondGiftSet = new GiftSet { Id = 2, Name = "Second" };
            var thirdGiftSet = new GiftSet { Id = 3, Name = "Third" };

            this.db.AddRange(firstGiftSet, secondGiftSet, thirdGiftSet);
            this.db.SaveChanges();

            var giftSetService = new ShoppingGiftSetService(this.db);

            IDictionary<int, int> idsWithQuantity = new Dictionary<int, int>()
            {
                {1,3 },
                {2,3 }
            };

            // Act
            var result = giftSetService.ByIds(idsWithQuantity);

            // Assert
            result
                .Should()
                .Match(r =>
                    (r.ElementAt(0).Id == 1 && r.ElementAt(0).Quantity == 3)
                    && (r.ElementAt(1).Id == 2 && r.ElementAt(1).Quantity == 3))
                .And
                .HaveCount(2);
        }
        [Fact]
        public void ExistsShouldReturnTrueIfItemExist()
        {
            //Arrange
            var firstGiftSet = new GiftSet { Id = 1, Name = "First" };

            this.db.Add(firstGiftSet);
            this.db.SaveChanges();

            var giftSetService = new ShoppingGiftSetService(this.db);
            //Act
            var result = giftSetService.Exists(1);

            //Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void ExistsShouldReturnFalseIfItemExist()
        {
            //Arrange
            var firstGiftSet = new GiftSet { Id = 1, Name = "First" };

            this.db.Add(firstGiftSet);
            this.db.SaveChanges();

            var giftSetService = new ShoppingGiftSetService(this.db);
            //Act
            var result = giftSetService.Exists(2);

            //Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TotalShouldReturnCorrectResult()
        {
            //Arrange
            var firstGiftSet = new GiftSet { Id = 1, Name = "First" };
            var secondGiftSet = new GiftSet { Id = 2, Name = "Second" };
            var thirdGiftSet = new GiftSet { Id = 3, Name = "Third" };

            this.db.AddRange(firstGiftSet, secondGiftSet, thirdGiftSet);
            this.db.SaveChanges();

            var giftSetService = new ShoppingGiftSetService(this.db);
            //Act
            var result = giftSetService.Total();

            //Assert
            result
                .Should()
                .Equals(3);
        }
    }
}

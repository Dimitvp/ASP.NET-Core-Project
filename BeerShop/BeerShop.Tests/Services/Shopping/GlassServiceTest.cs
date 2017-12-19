namespace BeerShop.Tests.Services.Shopping
{
    using BeerShop.Models.Products;
    using BeerShop.Services.Shopping.Implementations;
    using Data;
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class GlassServiceTest
    {
        private BeerShopDbContext db;

        public GlassServiceTest()
        {
            Tests.Initialize();
            this.db = Tests.GetDatabase();
        }

        [Fact]
        public void SearchShouldReturnCorrectResultsWithFilterAndOrder()
        {
            // Arrange
            var firstGlass = new Glass { Id = 1, Name = "First" };
            var secondGlass = new Glass { Id = 2, Name = "Second" };
            var thirdGlass = new Glass { Id = 3, Name = "Third" };

            this.db.AddRange(firstGlass, secondGlass, thirdGlass);
            this.db.SaveChanges();

            var glassService = new ShoppingGlassService(this.db);

            // Act
            var result = glassService.Search("d");
            var secondResult = glassService.Search(string.Empty);

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
            var firstGlass = new Glass { Id = 1, Name = "First" };
            var secondGlass = new Glass { Id = 2, Name = "Second" };
            var thirdGlass = new Glass { Id = 3, Name = "Third" };

            this.db.AddRange(firstGlass, secondGlass, thirdGlass);
            this.db.SaveChanges();

            var glassService = new ShoppingGlassService(this.db);

            IDictionary<int, int> idsWithQuantity = new Dictionary<int, int>()
            {
                {1,3 },
                {2,3 }
            };

            // Act
            var result = glassService.ByIds(idsWithQuantity);

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
            var firstGlass = new Glass { Id = 1, Name = "First" };

            this.db.Add(firstGlass);
            this.db.SaveChanges();

            var glassService = new ShoppingGlassService(this.db);
            //Act
            var result = glassService.Exists(1);

            //Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void ExistsShouldReturnFalseIfItemExist()
        {
            //Arrange
            var firstGlass = new Glass { Id = 1, Name = "First" };

            this.db.Add(firstGlass);
            this.db.SaveChanges();

            var glassService = new ShoppingGlassService(this.db);
            //Act
            var result = glassService.Exists(2);

            //Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TotalShouldReturnCorrectResult()
        {
            //Arrange
            var firstGlass = new Glass { Id = 1, Name = "First" };
            var secondGlass = new Glass { Id = 2, Name = "Second" };
            var thirdGlass = new Glass { Id = 3, Name = "Third" };

            this.db.AddRange(firstGlass, secondGlass, thirdGlass);
            this.db.SaveChanges();

            var glassService = new ShoppingGlassService(this.db);
            //Act
            var result = glassService.Total();

            //Assert
            result
                .Should()
                .Equals(3);
        }
    }
}

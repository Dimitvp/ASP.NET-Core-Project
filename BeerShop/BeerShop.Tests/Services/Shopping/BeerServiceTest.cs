namespace BeerShop.Tests.Services.Shopping
{
    using BeerShop.Services.Shopping.Implementations;
    using Data;
    using FluentAssertions;
    using Models.Products;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class BeerServiceTest
    {
        private BeerShopDbContext db;

        public BeerServiceTest()
        {
            Tests.Initialize();
            this.db = Tests.GetDatabase();
        }

        [Fact]
        public void SearchShouldReturnCorrectResultsWithFilterAndOrder()
        {
            // Arrange

            var firstBeer = new Beer { Id = 1, Name = "First" };
            var secondBeer = new Beer { Id = 2, Name = "Second" };
            var thirdBeer = new Beer { Id = 3, Name = "Third" };

            this.db.AddRange(firstBeer, secondBeer, thirdBeer);
            this.db.SaveChanges();

            var beerService = new ShoppingBeerService(this.db);

            // Act
            var result = beerService.Search("t");

            // Assert
            result.Should()
                .Match(r =>
                    r.ElementAt(0).Id == 3
                    && r.ElementAt(1).Id == 1)
                .And
                .HaveCount(2);
        }

        [Fact]
        public void ByIdsShouldReturnCorrectIdsWithCorrectQuantity()
        {
            // Arrange
            var firstBeer = new Beer { Id = 1, Name = "First" };
            var SecondBeer = new Beer { Id = 2, Name = "Second" };
            var ThirdBeer = new Beer { Id = 3, Name = "Third" };

            this.db.AddRange(firstBeer, SecondBeer, ThirdBeer);
            this.db.SaveChanges();

            var beerService = new ShoppingBeerService(this.db);

            IDictionary<int, int> idsWithQuantity = new Dictionary<int, int>()
            {
                {1,3 },
                {2,3 }
            };

            // Act
            var result = beerService.ByIds(idsWithQuantity);

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
            var firstBeer = new Beer { Id = 1, Name = "First" };

            this.db.Add(firstBeer);
            this.db.SaveChanges();

            var beerService = new ShoppingBeerService(this.db);
            //Act
            var result = beerService.Exists(1);

            //Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void ExistsShouldReturnFalseIfItemExist()
        {
            //Arrange
            var firstBeer = new Beer { Id = 1, Name = "First" };

            this.db.Add(firstBeer);
            this.db.SaveChanges();

            var beerService = new ShoppingBeerService(this.db);
            //Act
            var result = beerService.Exists(2);

            //Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TotalShouldReturnCorrectResult()
        {
            //Arrange
            var firstBeer = new Beer { Id = 1, Name = "First" };
            var secondBeer = new Beer { Id = 2, Name = "Second" };
            var thirdBeer = new Beer { Id = 3, Name = "Third" };

            this.db.AddRange(firstBeer, secondBeer, thirdBeer);
            this.db.SaveChanges();

            var beerService = new ShoppingBeerService(this.db);
            //Act
            var result = beerService.Total();

            //Assert
            result
                .Should()
                .Equals(3);
        }
    }
}

namespace BeerShop.Tests.Services.Administration
{
    using BeerShop.Models.Enums;
    using BeerShop.Models.Products;
    using BeerShop.Services.Administration.Implementations;
    using Data;
    using FluentAssertions;
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
        public void TotalShouldReturnCorrectCount()
        {
            // Arrange
            var firstBeer = new Beer { Id = 1, Name = "First" };
            var secondBeer = new Beer { Id = 2, Name = "Second" };
            var thirdBeer = new Beer { Id = 3, Name = "Third" };

            this.db.AddRange(firstBeer, secondBeer, thirdBeer);
            this.db.SaveChanges();

            var beerService = new AdminBeerService(this.db);

            // Act
            var result = beerService.Total("");
            var secondResult = beerService.Total("d");

            // Assert
            result
                .Should()
                .Equals(3);

            secondBeer
                .Should()
                .Equals(2);
        }

        [Fact]
        public void CreateShoultReturnCorrectId()
        {
            // Arrange

            var beerService = new AdminBeerService(this.db);

            // Act
            var result = beerService.Create("", 1m, 1, "", 2, 3, "", BeerColor.Amber, 2, 3, 4, 3, 1, 2);

            // Assert
            result
                .Should()
                .Equals(1);
        }

        [Fact]
        public void EditShouldReturnTrueIfItIsSuccessfull()
        {
            // Arrange
            var beer = new Beer
            {
                Id = 1,
                Name = "Test"
            };

            this.db.Beers.Add(beer);
            this.db.SaveChanges();

            var beerService = new AdminBeerService(this.db);

            // Act
            var result = beerService.Edit(1, "test", 2m, 1, "test", 2, 2, "", BeerColor.Amber, 1, 2, 3, 2, 1, 1);

            // Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void EditShouldReturnFalseIfItIsNotSuccessfull()
        {
            // Arrange
            var beerService = new AdminBeerService(this.db);

            // Act
            var result = beerService.Edit(2, "test", 2m, 1, "test", 2, 2, "", BeerColor.Amber, 1, 2, 3, 2, 1, 1);


            // Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void DeleteShouldReturnTrueIfItIsSuccessfull()
        {
            // Arrange
            var beer = new Beer
            {
                Id = 1,
                Name = "Test"
            };

            this.db.Beers.Add(beer);
            this.db.SaveChanges();

            var beerService = new AdminBeerService(this.db);

            // Act
            var result = beerService.Delete(1);

            // Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void DeleteShouldReturnFalseIfItIsNotSuccessfull()
        {
            // Arrange
            var beerService = new AdminBeerService(this.db);

            // Act
            var result = beerService.Delete(1);

            // Assert
            result
                .Should()
                .BeFalse();
        }
    }
}

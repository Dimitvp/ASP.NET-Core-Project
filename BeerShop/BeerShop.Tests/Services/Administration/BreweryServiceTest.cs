namespace BeerShop.Tests.Services.Administration
{
    using BeerShop.Models;
    using BeerShop.Services.Administration.Implementations;
    using Data;
    using FluentAssertions;
    using Xunit;

    public class BreweryServiceTest
    {
        private BeerShopDbContext db;

        public BreweryServiceTest()
        {
            this.db = Tests.GetDatabase();
        }

        [Fact]
        public void TotalShouldReturnCorrectCount()
        {
            // Arrange
            var first = new Brewery { Id = 1, Name = "First" };
            var second = new Brewery { Id = 2, Name = "Second" };
            var third = new Brewery { Id = 3, Name = "Third" };

            this.db.Breweries.AddRange(first, second, third);
            this.db.SaveChanges();

            var breweryService = new AdminBreweryService(this.db);

            // Act
            var result = breweryService.Total();

            // Assert
            result
                .Should()
                .Equals(3);
        }

        [Fact]
        public void EditShouldReturnTrueIfItIsSuccessfull()
        {
            // Arrange
            var first = new Brewery { Id = 1, Name = "First" };

            this.db.Breweries.Add(first);
            this.db.SaveChanges();

            var breweryService = new AdminBreweryService(this.db);

            // Act
            var result = breweryService.Edit(1, "test", "test", 1);

            // Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void EditShouldReturnFalseIfItIsNotSuccessfull()
        {
            // Arrange
            var breweryService = new AdminBreweryService(this.db);

            // Act
            var result = breweryService.Edit(1, "test", "test", 1);

            // Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void DeleteShouldReturnTrueIfItIsSuccessfull()
        {
            // Arrange
            var first = new Brewery { Id = 1, Name = "First" };

            this.db.Breweries.Add(first);
            this.db.SaveChanges();

            var breweryService = new AdminBreweryService(this.db);

            // Act
            var result = breweryService.Delete(1);

            // Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void DeleteShouldReturnFalseIfItIsNotSuccessfull()
        {
            // Arrange
            var breweryService = new AdminBreweryService(this.db);

            // Act
            var result = breweryService.Delete(1);

            // Assert
            result
                .Should()
                .BeFalse();
        }
    }
}

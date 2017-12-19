namespace BeerShop.Tests.Services.Administration
{
    using BeerShop.Models;
    using BeerShop.Services.Administration.Implementations;
    using Data;
    using FluentAssertions;
    using Xunit;

    public class CountryServiceTest
    {
        private BeerShopDbContext db;

        public CountryServiceTest()
        {
            this.db = Tests.GetDatabase();
        }

        [Fact]
        public void DeleteShouldReturnTrueIfItIsSuccessfull()
        {
            // Arrange
            var first = new Country { Id = 1, Name = "First" };

            this.db.Countries.Add(first);
            this.db.SaveChanges();

            var countryService = new AdminCountryService(this.db);

            // Act
            var result = countryService.Delete(1);

            // Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void DeleteShouldReturnFalseIfItIsNotSuccessfull()
        {
            // Arrange
            var countryService = new AdminCountryService(this.db);

            // Act
            var result = countryService.Delete(1);

            // Assert
            result
                .Should()
                .BeFalse();
        }
    }
}

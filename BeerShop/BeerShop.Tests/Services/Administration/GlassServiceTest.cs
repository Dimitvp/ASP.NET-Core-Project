namespace BeerShop.Tests.Services.Administration
{
    using BeerShop.Models.Enums;
    using BeerShop.Models.Products;
    using BeerShop.Services.Administration.Implementations;
    using Data;
    using FluentAssertions;
    using Xunit;

    public class GlassServiceTest
    {
        private BeerShopDbContext db;

        public GlassServiceTest()
        {
            this.db = Tests.GetDatabase();
        }

        [Fact]
        public void TotalShouldReturnCorrectCount()
        {
            // Arrange
            var first = new Glass { Id = 1, Name = "First" };
            var second = new Glass { Id = 2, Name = "Second" };
            var third = new Glass { Id = 3, Name = "Third" };

            this.db.AddRange(first, second, third);
            this.db.SaveChanges();

            var giftSetService = new AdminGlassService(this.db);

            // Act
            var result = giftSetService.Total("");
            var secondResult = giftSetService.Total("d");

            // Assert
            result
                .Should()
                .Equals(3);

            secondResult
                .Should()
                .Equals(2);

        }

        [Fact]
        public void CreateShoultReturnCorrectId()
        {
            // Arrange
            var glassService = new AdminGlassService(this.db);

            // Act
            var result = glassService.Create("test", "test", 2, Material.Glass, 1, 2);

            // Assert
            result
                .Should()
                .Equals(1);
        }

        [Fact]
        public void EditShouldReturnTrueIfItIsSuccessfull()
        {
            // Arrange
            var glass = new Glass
            {
                Id = 1,
                Name = "Test"
            };

            this.db.Glasses.Add(glass);
            this.db.SaveChanges();

            var glassService = new AdminGlassService(this.db);

            // Act
            var result = glassService.Edit(1, "", "",2, Material.Glass, 1, 2m);

            // Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void EditShouldReturnFalseIfItIsNotSuccessfull()
        {
            // Arrange
            var glassService = new AdminGlassService(this.db);

            // Act
            var result = glassService.Edit(1, "", "", 2, Material.Glass, 1, 2m);


            // Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void DeleteShouldReturnTrueIfItIsSuccessfull()
        {
            // Arrange
            var glass = new Glass
            {
                Id = 1,
                Name = "Test"
            };

            this.db.Glasses.Add(glass);
            this.db.SaveChanges();

            var glassService = new AdminGlassService(this.db);

            // Act
            var result = glassService.Delete(1);

            // Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void DeleteShouldReturnFalseIfItIsNotSuccessfull()
        {
            // Arrange
            var glassService = new AdminGlassService(this.db);

            // Act
            var result = glassService.Delete(1);

            // Assert
            result
                .Should()
                .BeFalse();
        }
    }
}

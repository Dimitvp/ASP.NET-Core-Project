namespace BeerShop.Tests.Web.Areas.Shopping
{
    using BeerShop.Services.Shopping;
    using BeerShop.Web.Areas.Shopping.Controllers;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Moq;
    using System.Linq;
    using Xunit;

    using static BeerShop.Web.WebConstants;

    public class NewsletterControllerTest
    {
        private const string Email = "test@test.test";

        [Fact]
        public void ControllerShouldBeInShoppingArea()
        {
            // Arrange
            var controller = typeof(NewsLetterController);

            // Act
            var attribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AreaAttribute)) as AreaAttribute;

            // Assert
            attribute.Should().NotBeNull();
            attribute.RouteValue.Should().Be(ShopArea);
        }

        [Fact]
        public void PostSubscribeShouldReturnRedictViewIfYouAlreadySubsciber()
        {
            // Arrange
            var warningMessage = string.Empty;

            var newsletterService = new Mock<IShoppingNewsLetterService>();
            newsletterService
                .Setup(n => n.Exists(It.IsAny<string>()))
                .Returns(true);

            var tempData = new Mock<ITempDataDictionary>();
            tempData
                .SetupSet(t => t[TempDataWarningMessageKey] = It.IsAny<string>())
                .Callback((string key, object message) => warningMessage = message as string);

            var controller = new NewsLetterController(newsletterService.Object)
            {
                TempData = tempData.Object
            };

            // Act
            var result = controller.Subscribe(Email);

            // Assert
            warningMessage.Should().Be(string.Format(EmailAlreadySubscribed, Email));

            result.Should().BeOfType<RedirectToActionResult>();

            result.As<RedirectToActionResult>().ActionName.Should().Be("Index");
            result.As<RedirectToActionResult>().ControllerName.Should().Be("Home");
        }
        
        [Fact]
        public void PostSubscribeShouldReturnRedirectViewIfSubscriptionIsNotSuccessfull()
        {
            // Arrange
            var warningMessage = string.Empty;

            var newsletterService = new Mock<IShoppingNewsLetterService>();
            newsletterService
                .Setup(n => n.Create(It.IsAny<string>()))
                .Returns(false);

            var tempData = new Mock<ITempDataDictionary>();
            tempData
                .SetupSet(t => t[TempDataWarningMessageKey] = It.IsAny<string>())
                .Callback((string key, object message) => warningMessage = message as string);

            var controller = new NewsLetterController(newsletterService.Object)
            {
                TempData = tempData.Object
            };

            // Act
            var result = controller.Subscribe(Email);

            // Assert
            warningMessage.Should().Be(string.Format(InvalidEmailAddress, Email));

            result.Should().BeOfType<RedirectToActionResult>();

            result.As<RedirectToActionResult>().ActionName.Should().Be("Index");
            result.As<RedirectToActionResult>().ControllerName.Should().Be("Home");
        }

        [Fact]
        public void PostSubscribeShouldReturnRedirectViewIfSubscriptionIsSuccessfull()
        {
            // Arrange
            var successMessage = string.Empty;

            var newsletterService = new Mock<IShoppingNewsLetterService>();
            newsletterService
                .Setup(n => n.Create(It.IsAny<string>()))
                .Returns(true);

            var tempData = new Mock<ITempDataDictionary>();
            tempData
                .SetupSet(t => t[TempDataSuccessMessageKey] = It.IsAny<string>())
                .Callback((string key, object message) => successMessage = message as string);

            var controller = new NewsLetterController(newsletterService.Object)
            {
                TempData = tempData.Object
            };

            // Act
            var result = controller.Subscribe(Email);

            // Assert
            successMessage.Should().Be(SuccessfullSubscribtion);

            result.Should().BeOfType<RedirectToActionResult>();

            result.As<RedirectToActionResult>().ActionName.Should().Be("Index");
            result.As<RedirectToActionResult>().ControllerName.Should().Be("Home");
        }
    }
}

namespace BeerShop.Tests.Web.Areas.Administration
{
    using AutoMapper;
    using BeerShop.Services.Administration;
    using BeerShop.Services.Administration.Models.Accessories;
    using BeerShop.Web.Areas.Administration.Controllers;
    using BeerShop.Web.Areas.Administration.Models.Accessories;
    using FluentAssertions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    using static BeerShop.Web.WebConstants;

    public class AccessoriesControllerTest
    {
        private const int Id = 1;
        private const string Name = "Accessory Name";
        private const string Description = "Description Test";
        private const int Quantity = 1;
        private const decimal Price = 2m;

        [Fact]
        public void ControllerShouldBeInAdministrationArea()
        {
            // Arrange
            var controller = typeof(AccessoriesController);

            // Act
            var attribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AreaAttribute)) as AreaAttribute;

            // Assert
            attribute.Should().NotBeNull();
            attribute.RouteValue.Should().Be(AdminArea);
        }

        [Fact]
        public void ControllerShouldBeAccessibleForAdministratorsOnly()
        {
            // Arrange
            var controller = typeof(AccessoriesController);

            // Act
            var attribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AuthorizeAttribute)) as AuthorizeAttribute;

            // Assert
            attribute.Should().NotBeNull();
            attribute.Roles.Should().Be(AdminRole);
        }

        [Fact]
        public void GetAllShouldReturnViewWithCorrectModel()
        {
            // Arrange
            var accessoryService = new Mock<IAdminAccessoryService>();
            accessoryService
                .Setup(a => a.AllListing(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<AccessoryListingServiceModel>
                {
                    new AccessoryListingServiceModel { Id = 1}
                });

            var controller = new AccessoriesController(accessoryService.Object, null);

            // Act
            var result = controller.All();

            // Assert
            result.Should().BeOfType<ViewResult>();

            var model = result.As<ViewResult>().Model;

            model.Should().BeOfType<AccessoryPageListingViewModel>();

            var pageListingModel = model.As<AccessoryPageListingViewModel>();

            pageListingModel.Accessories.Should().HaveCount(1);
        }

        [Fact]
        public void GetCreateShouldReturnView()
        {
            // Arrange
            var controller = new AccessoriesController(null, null);

            // Act
            var result = controller.Create();

            // Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void PostCreateShouldReturnViewWithCorrectModelWhenModelStateIsInvalid()
        {
            // Arrange
            var controller = new AccessoriesController(null, null);
            controller.ModelState.AddModelError(string.Empty, "Error");

            // Act
            var result = controller.Create(new AccessoryFormViewModel());

            // Assert
            result.Should().BeOfType<ViewResult>();

            var model = result.As<ViewResult>().Model;

            model.Should().BeOfType<AccessoryFormViewModel>();
        }

        [Fact]
        public void PostCreateShouldReturnRedirectWithValidModel()
        {
            // Arrange
            string modelName = null;
            string modelDescription = null;
            var modelQuantity = 0;
            var modelPrice = 0m;
            string successMessage = null;

            var accessoryService = new Mock<IAdminAccessoryService>();
            accessoryService
                .Setup(a => a.Create(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<decimal>()))
                .Callback((string name, string description, int quantity, decimal price) =>
                {
                    modelName = name;
                    modelDescription = description;
                    modelQuantity = quantity;
                    modelPrice = price;
                });

            var tempData = new Mock<ITempDataDictionary>();
            tempData
                .SetupSet(t => t[TempDataSuccessMessageKey] = It.IsAny<string>())
                .Callback((string key, object message) => successMessage = message as string);

            var controller = new AccessoriesController(accessoryService.Object, null)
            {
                TempData = tempData.Object
            };

            // Act
            var result = controller.Create(new AccessoryFormViewModel
            {
                Name = Name,
                Description = Description,
                Price = Price,
                Quantity = Quantity
            });

            // Assert
            modelName.Should().Be(Name);
            modelDescription.Should().Be(Description);
            modelPrice.Should().Be(Price);
            modelQuantity.Should().Be(Quantity);

            successMessage.Should().Be(string.Format(SuccessfullAdd, Name));

            result.Should().BeOfType<RedirectToActionResult>();

            result.As<RedirectToActionResult>().ActionName.Should().Be("All");
        }

        [Fact]
        public void GetEditShouldReturnNotFoundWithInvalidModelId()
        {
            // Arrange
            var accessoryService = new Mock<IAdminAccessoryService>();
            accessoryService
                .Setup(a => a.ById(It.Is<int>(id => id == Id)))
                .Returns(new AccessoryEditServiceModel { Name = Name });

            var controller = new AccessoriesController(accessoryService.Object, null);

            // Act
            var result = controller.Edit(2);

            // Assert
            result
                .Should()
                .BeOfType<NotFoundResult>();
        }

        [Fact]
        public void GetEditShouldReturnViewWithValidModel()
        {
            // Arrange
            var mapper = this.GetMapper();

            var accessoryService = new Mock<IAdminAccessoryService>();
            accessoryService
                .Setup(a => a.ById(It.Is<int>(id => id == Id)))
                .Returns(new AccessoryEditServiceModel { Name = Name });

            var controller = new AccessoriesController(accessoryService.Object, mapper.Object);

            // Act
            var result = controller.Edit(1);

            // Assert
            result
                .Should()
                .BeOfType<ViewResult>();

            var model = result.As<ViewResult>().Model;

            model.Should().BeOfType<AccessoryFormViewModel>();
        }

        [Fact]
        public void PostEditShouldReturnViewIfModelIsNotValid()
        {
            // Arrange
            var controller = new AccessoriesController(null, null);
            controller.ModelState.AddModelError(string.Empty, "Error");

            // Act
            var result = controller.Edit(1, new AccessoryFormViewModel());

            // Assert
            result.Should().BeOfType<ViewResult>();

            var model = result.As<ViewResult>().Model;

            model.Should().BeOfType<AccessoryFormViewModel>();
        }

        [Fact]
        public void PostEditShouldRedirectWithValidModel()
        {
            int modelId = Id;
            string modelName = null;
            string modelDescription = null;
            var modelQuantity = 0;
            var modelPrice = 0m;
            string warningMessage = null;

            var accessoryService = new Mock<IAdminAccessoryService>();
            accessoryService
                .Setup(a => a.Edit(
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<decimal>()))
                .Callback((int id, string name, string description, int quantity, decimal price) =>
                {
                    modelId = id;
                    modelName = name;
                    modelDescription = description;
                    modelQuantity = quantity;
                    modelPrice = price;
                })
                .Returns(true);

            var tempData = new Mock<ITempDataDictionary>();
            tempData
                .SetupSet(t => t[TempDataWarningMessageKey] = It.IsAny<string>())
                .Callback((string key, object message) => warningMessage = message as string);

            var controller = new AccessoriesController(accessoryService.Object, null)
            {
                TempData = tempData.Object
            };

            // Act
            var result = controller.Edit(Id, new AccessoryFormViewModel
            {
                Name = Name,
                Description = Description,
                Price = Price,
                Quantity = Quantity
            });

            // Assert
            modelId.Should().Be(Id);
            modelName.Should().Be(Name);
            modelDescription.Should().Be(Description);
            modelPrice.Should().Be(Price);
            modelQuantity.Should().Be(Quantity);

            warningMessage.Should().Be(string.Format(SuccessfullEdit, Name));

            result.Should().BeOfType<RedirectToActionResult>();

            result.As<RedirectToActionResult>().ActionName.Should().Be("All");
        }

        [Fact]
        public void PostEditShouldReturnBadRequestIfFailedToEdit()
        {
            // Arrange

            var accessoryService = new Mock<IAdminAccessoryService>();
            accessoryService
                .Setup(a => a.Edit(
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<decimal>()))
                .Returns(false);

            var controller = new AccessoriesController(accessoryService.Object, null);

            // Act
            var result = controller.Edit(Id, new AccessoryFormViewModel
            {
                Name = Name,
                Description = Description,
                Price = Price,
                Quantity = Quantity
            });

            // Assert
            result
                .Should()
                .BeOfType<BadRequestResult>();
        }

        [Fact]
        public void GetDeleteShouldReturnNotFoundIfIdIsInvalid()
        {
            // Arrange
            var accessoryService = new Mock<IAdminAccessoryService>();
            accessoryService
                .Setup(a => a.ById(It.Is<int>(id => id == Id)))
                .Returns(new AccessoryEditServiceModel { Name = Name });

            var controller = new AccessoriesController(accessoryService.Object, null);

            // Act
            var result = controller.Delete(2, string.Empty);

            // Assert
            result
                .Should()
                .BeOfType<NotFoundResult>();
        }

        [Fact]
        public void GetDeleteShouldReturnViewWitchCorrectModel()
        {
            // Arrange
            var mapper = this.GetMapper();

            var accessoryService = new Mock<IAdminAccessoryService>();
            accessoryService
                .Setup(a => a.ById(It.Is<int>(id => id == Id)))
                .Returns(new AccessoryEditServiceModel { Name = Name });

            var controller = new AccessoriesController(accessoryService.Object, mapper.Object);

            // Act
            var result = controller.Delete(1, string.Empty);

            // Assert
            result
                .Should()
                .BeOfType<ViewResult>();

            var model = result.As<ViewResult>().Model;

            model.Should().BeOfType<AccessoryFormViewModel>();
        }

        [Fact]
        public void PostDeleteShouldReturnBadRequestIfIdIsInvalid()
        {
            // Arrange
            var accessoryService = new Mock<IAdminAccessoryService>();
            accessoryService
                .Setup(a => a.Delete(It.IsAny<int>()))
                .Returns(false);

            var controller = new AccessoriesController(accessoryService.Object, null);

            // Act
            var result = controller.Delete(Id);

            // Assert
            result
                .Should()
                .BeOfType<BadRequestResult>();
        }

        [Fact]
        public void PostDeleteShouldRedirectToViewIfSuccessfull()
        {
            // Arrange
            var dangerMessage = string.Empty;

            var accessoryService = new Mock<IAdminAccessoryService>();
            accessoryService
                .Setup(a => a.Delete(It.IsAny<int>()))
                .Returns(true);

            var tempData = new Mock<ITempDataDictionary>();
            tempData
                .SetupSet(t => t[TempDataDangerMessageKey] = It.IsAny<string>())
                .Callback((string key, object message) => dangerMessage = message as string);

            var controller = new AccessoriesController(accessoryService.Object, null)
            {
                TempData = tempData.Object
            };

            // Act
            var result = controller.Delete(Id);

            // Assert
            dangerMessage.Should().Be(SuccessfullDelete);

            result.Should().BeOfType<RedirectToActionResult>();

            result.As<RedirectToActionResult>().ActionName.Should().Be("All");
        }

        private Mock<IMapper> GetMapper()
        {
            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<AccessoryFormViewModel>(It.IsAny<AccessoryEditServiceModel>()))
            .Returns(new AccessoryFormViewModel());

            return mapper;
        }
    }
}

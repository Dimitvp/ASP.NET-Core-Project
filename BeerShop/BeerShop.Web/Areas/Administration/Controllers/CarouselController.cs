namespace BeerShop.Web.Areas.Administration.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Models.Carousel;

    using static WebConstants;

    public class CarouselController : AdminBaseController
    {
        private const string FirstImageName = "01";
        private const string SecondImageName = "02";
        private const string ThirdImageName = "03";

        private const string WarningMessage = "Please choose one or more images for upload";
        private const string SuccessMessage = "Upload was successfull";

        public IActionResult Upload() => View();

        [HttpPost]
        public IActionResult Upload(CarouselUploadImageFormViewModel model)
        {
            if (model.FirstImage == null
                && model.SecondImage == null
                && model.ThirdImage == null)
            {
                this.TempData.AddWarningMessage(WarningMessage);
                return View();
            }

            if (model.FirstImage.HasValidImage())
            {
                model.FirstImage.SaveImage(FirstImageName, CarouselImagesPath);
            }

            if (model.SecondImage.HasValidImage())
            {
                model.SecondImage.SaveImage(SecondImageName, CarouselImagesPath);
            }

            if (model.ThirdImage.HasValidImage())
            {
                model.ThirdImage.SaveImage(ThirdImageName, CarouselImagesPath);
            }

            this.TempData.AddSuccessMessage(SuccessMessage);

            return RedirectToAction(nameof(Upload));
        }
    }
}

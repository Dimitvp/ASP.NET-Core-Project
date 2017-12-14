namespace BeerShop.Web.Areas.Administration.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models.Carousel;
    using System.IO;
    using static WebConstants;

    public class CarouselController : AdminBaseController
    {
        public IActionResult Upload() => View();

        [HttpPost]
        public IActionResult Upload(CarouselUploadImageFormViewModel model)
        {
            if (model.FirstImage == null
                && model.SecondImage == null
                && model.ThirdImage == null)
            {
                this.TempData.AddWarningMessage("Please choose image/s to upload");
                return View();
            }

            if (this.HasValidImage(model.FirstImage))
            {
                this.SaveImage("01", model.FirstImage);
            }

            if (this.HasValidImage(model.SecondImage))
            {
                this.SaveImage("02", model.SecondImage);
            }

            if (this.HasValidImage(model.ThirdImage))
            {
                this.SaveImage("03", model.ThirdImage);
            }

            this.TempData.AddSuccessMessage("Upload was successfull");

            return RedirectToAction(nameof(Upload));
        }

        private void SaveImage(string imageName, IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);

            var filePath = Path
                .Combine(Directory.GetCurrentDirectory(),
                    CarouselImagesPath,
                    imageName + extension);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }

        private bool HasValidImage(IFormFile image)
            => image != null
                && image.Length <= ImageSize
                && (image.FileName.EndsWith(JpgFormat)
                    || image.FileName.EndsWith(PngFormat));
    }
}

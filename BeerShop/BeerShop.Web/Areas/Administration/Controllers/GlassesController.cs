namespace BeerShop.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models.Glasses;
    using Services.Administration;
    using System;
    using System.IO;

    using static WebConstants;

    public class GlassesController : AdminBaseController
    {
        private readonly IAdminGlassService glasses;
        private readonly IMapper mapper;

        public GlassesController(IAdminGlassService glasses, IMapper mapper)
        {
            this.glasses = glasses;
            this.mapper = mapper;
        }

        public IActionResult All(string searchTerm, int page = DefaultPage)
        {
            var glasses = this.glasses.AllListing(searchTerm, page, PageSize);

            return View(new GlassPageListingViewModel
            {
                Glasses = glasses,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.glasses.Total(searchTerm) / (double)PageSize),
                SearchTerm = searchTerm
            });
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(GlassFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var glassId = this.glasses.Create(
                                model.Name,
                                model.Description,
                                model.Volume,
                                model.Material,
                                model.Quantity,
                                model.Price);

            if (this.HasValidImage(model.Image))
            {
                var imageName = this.SaveImage(glassId, model.Image);
                this.glasses.SetImage(glassId, imageName);
            }

            this.TempData.AddSuccessMessage(string.Format(SuccessfullAdd, model.Name));

            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var glass = this.glasses.ById(id);

            if (glass == null)
            {
                return NotFound();
            }

            var glassFormModel = this.mapper.Map<GlassFormViewModel>(glass);

            return View(glassFormModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, GlassFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (this.HasValidImage(model.Image))
            {
                this.glasses.SetImage(id, this.SaveImage(id, model.Image));
            }

            var success = this.glasses.Edit(
                            id,
                            model.Name,
                            model.Description,
                            model.Volume,
                            model.Material,
                            model.Quantity,
                            model.Price);

            if (!success)
            {
                return BadRequest();
            }

            this.TempData.AddWarningMessage(string.Format(SuccessfullEdit, model.Name));

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id, string name = null)
        {
            var glass = this.glasses.ById(id);

            if (glass == null)
            {
                return NotFound();
            }

            var glassFormModel = this.mapper.Map<GlassFormViewModel>(glass);

            return View(glassFormModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var success = this.glasses.Delete(id);

            if (!success)
            {
                return BadRequest();
            }

            this.TempData.AddDangerMessage(SuccessfullDelete);

            return RedirectToAction(nameof(All));
        }

        private string SaveImage(int glassId, IFormFile file)
        {
            var imageName = file.FileName.ToImageName(glassId);

            var filePath = Path
                .Combine(Directory.GetCurrentDirectory(),
                GlassesImagesPath,
                imageName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return imageName;
        }

        private bool HasValidImage(IFormFile image)
            => image != null
                && image.Length <= ImageSize
                && (image.FileName.EndsWith(JpgFormat)
                    || image.FileName.EndsWith(PngFormat));
    }
}

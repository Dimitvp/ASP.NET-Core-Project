namespace BeerShop.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using BeerShop.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models.Glasses;
    using Services.Administration;
    using System;
    using System.IO;

    public class GlassesController : AdminBaseController
    {
        private readonly IAdminGlassService glasses;
        private readonly IMapper mapper;

        public GlassesController(IAdminGlassService glasses, IMapper mapper)
        {
            this.glasses = glasses;
            this.mapper = mapper;
        }

        public IActionResult All(string searchTerm, int page = WebConstants.DefaultPage)
        {
            var glasses = this.glasses.AllListing(searchTerm, page, WebConstants.PageSize);

            return View(new GlassPageListingViewModel
            {
                Glasses = glasses,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.glasses.Total(searchTerm) / (double)WebConstants.PageSize),
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

            var imageName = string.Empty;

            if (model.Image != null
                && model.Image.Length < WebConstants.ImageSize)
            {
                imageName = this.SaveImage(model.Name, model.Image);
            }

            this.glasses.Create(
                model.Name,
                model.Description,
                model.Volume,
                model.Material,
                model.Quantity,
                model.Price,
                imageName);

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

            var imageName = string.Empty;

            if (model.Image != null
                && model.Image.Length < WebConstants.ImageSize)
            {
                imageName = this.SaveImage(model.Name, model.Image);
            }

            var success = this.glasses.Edit(
                            id,
                            model.Name,
                            model.Description,
                            model.Volume,
                            model.Material,
                            model.Quantity,
                            model.Price,
                            imageName);

            if (!success)
            {
                return BadRequest();
            }

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

            return RedirectToAction(nameof(All));
        }

        private string SaveImage(string glassName, IFormFile file)
        {
            var indexOfDot = file.FileName.LastIndexOf('.');
            var imageName = file.FileName
                .Substring(indexOfDot)
                .Insert(0, glassName)
                .ToDashedString();

            var filePath = Path
                .Combine(Directory.GetCurrentDirectory(), "wwwroot",
                "Images",
                "Glasses",
                imageName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return imageName;
        }
    }
}

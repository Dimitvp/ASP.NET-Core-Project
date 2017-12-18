namespace BeerShop.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Models.Glasses;
    using Services.Administration;
    using System;

    using static WebConstants;

    public class GlassesController : AdminBaseController
    {
        private const string GlassProduct = "Glass";

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

            if (model.Image.HasValidImage())
            {
                var imageName = model.Image.SaveImage(glassId, GlassProduct, GlassesImagesPath);
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

            if (model.Image.HasValidImage())
            {
                this.glasses.SetImage(id, model.Image.SaveImage(id, GlassProduct, GlassesImagesPath));
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
    }
}

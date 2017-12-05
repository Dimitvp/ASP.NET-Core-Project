namespace BeerShop.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models.Accessories;
    using Services.Administration;
    using System;
    using System.IO;

    public class AccessoriesController : AdminBaseController
    {
        private readonly IAdminAccessoryService accessories;
        private readonly IMapper mapper;

        public AccessoriesController(IAdminAccessoryService accessories, IMapper mapper)
        {
            this.accessories = accessories;
            this.mapper = mapper;
        }

        public IActionResult All(int page = WebConstants.DefaultPage)
        {
            var accessories = this.accessories.AllListing(page, WebConstants.PageSize);

            return View(new AccessoryPageListingViewModel
            {
                Accessories = accessories,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.accessories.Total() / (double)WebConstants.PageSize)
            });
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(AccessoryFormViewModel model)
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

            this.accessories.Create(model.Name, model.Description, model.Quantity, model.Price, imageName);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var accessory = this.accessories.ById(id);

            if (accessories == null)
            {
                return NotFound();
            }

            var accessoryFormModel = this.mapper.Map<AccessoryFormViewModel>(accessory);

            return View(accessoryFormModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, AccessoryFormViewModel model)
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

            var success = this.accessories.Edit(id, model.Name, model.Description, model.Quantity, model.Price, imageName);

            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id, string empty)
        {
            var accessory = this.accessories.ById(id);

            if (accessories == null)
            {
                return NotFound();
            }

            var accessoryFormModel = this.mapper.Map<AccessoryFormViewModel>(accessory);

            return View(accessoryFormModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var success = this.accessories.Delete(id);

            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        private string SaveImage(string accessoryName, IFormFile file)
        {
            var indexOfDot = file.FileName.LastIndexOf('.');
            var imageName = file.FileName
                .Substring(indexOfDot)
                .Insert(0, accessoryName)
                .ToDashedString();

            var filePath = Path
                .Combine(Directory.GetCurrentDirectory(), "wwwroot",
                "Images",
                "Accessories",
                imageName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return imageName;
        }
    }
}

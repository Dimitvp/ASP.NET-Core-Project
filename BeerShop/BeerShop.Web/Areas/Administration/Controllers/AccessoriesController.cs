namespace BeerShop.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Models.Accessories;
    using Services.Administration;
    using System;

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

            this.accessories.Create(model.Name, model.Description, model.Quantity, model.Price);

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

            var success = this.accessories.Edit(id, model.Name, model.Description, model.Quantity, model.Price);

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
    }
}

﻿namespace BeerShop.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Models.Accessories;
    using Services.Administration;
    using System;

    using static WebConstants;

    public class AccessoriesController : AdminBaseController
    {
        private const string AccessoryProduct = "Accessory";

        private readonly IAdminAccessoryService accessories;
        private readonly IMapper mapper;

        public AccessoriesController(IAdminAccessoryService accessories, IMapper mapper)
        {
            this.accessories = accessories;
            this.mapper = mapper;
        }

        public IActionResult All(int page = DefaultPage)
        {
            var accessories = this.accessories.AllListing(page, PageSize);

            return View(new AccessoryPageListingViewModel
            {
                Accessories = accessories,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.accessories.Total() / (double)PageSize)
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

            var accessoryId = this.accessories.Create(
                                    model.Name,
                                    model.Description,
                                    model.Quantity,
                                    model.Price);

            if (model.Image.HasValidImage())
            {
                var imageName = model.Image.SaveImage(accessoryId, AccessoryProduct, AccessoriesImagesPath);
                this.accessories.SetImage(accessoryId, imageName);
            }

            this.TempData.AddSuccessMessage(string.Format(SuccessfullAdd, model.Name));

            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var accessory = this.accessories.ById(id);

            if (accessory == null)
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

            if (model.Image.HasValidImage())
            {
                this.accessories.SetImage(id, model.Image.SaveImage(id, AccessoryProduct, AccessoriesImagesPath));
            }

            var success = this.accessories.Edit(id,
                                    model.Name,
                                    model.Description,
                                    model.Quantity,
                                    model.Price);

            if (!success)
            {
                return BadRequest();
            }

            this.TempData.AddWarningMessage(string.Format(SuccessfullEdit, model.Name));

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id, string empty)
        {
            var accessory = this.accessories.ById(id);

            if (accessory == null)
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

            this.TempData.AddDangerMessage(SuccessfullDelete);

            return RedirectToAction(nameof(All));
        }
    }
}

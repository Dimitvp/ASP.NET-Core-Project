namespace BeerShop.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using BeerShop.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models.GiftSets;
    using Services.Administration;
    using System;
    using System.IO;

    using static WebConstants;

    public class GiftSetsController : AdminBaseController
    {
        private readonly IAdminGiftSetService giftSets;
        private readonly IMapper mapper;

        public GiftSetsController(IAdminGiftSetService giftSets, IMapper mapper)
        {
            this.giftSets = giftSets;
            this.mapper = mapper;
        }

        public IActionResult All(int page = DefaultPage)
        {
            var giftSets = this.giftSets.AllListing(page, PageSize);

            return View(new GiftSetPageListingViewModel
            {
                GiftSets = giftSets,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.giftSets.Total() / (double)PageSize)
            });
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(GiftSetFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var imageName = string.Empty;

            if (model.Image != null
                && model.Image.Length < ImageSize)
            {
                imageName = this.SaveImage(model.Name, model.Image);
            }

            this.giftSets.Create(model.Name, model.Description, model.Quantity, model.Price, imageName);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var giftSet = this.giftSets.ById(id);

            if (giftSet == null)
            {
                return NotFound();
            }

            var giftSetFormModel = this.mapper.Map<GiftSetFormViewModel>(giftSet);

            return View(giftSetFormModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, GiftSetFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var imageName = string.Empty;

            if (model.Image != null
                && model.Image.Length < ImageSize)
            {
                imageName = this.SaveImage(model.Name, model.Image);
            }

            var success = this.giftSets.Edit(id, model.Name, model.Description, model.Quantity, model.Price, imageName);

            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id, string empty)
        {
            var giftSet = this.giftSets.ById(id);

            if (giftSet == null)
            {
                return NotFound();
            }

            var giftSetFormModel = this.mapper.Map<GiftSetFormViewModel>(giftSet);

            return View(giftSetFormModel);
        }

        public IActionResult Delete(int id)
        {
            var success = this.giftSets.Delete(id);

            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        private string SaveImage(string giftSetName, IFormFile file)
        {
            var indexOfDot = file.FileName.LastIndexOf('.');
            var imageName = file.FileName
                .Substring(indexOfDot)
                .Insert(0, giftSetName)
                .ToDashedString();

            var filePath = Path
                .Combine(Directory.GetCurrentDirectory(), "wwwroot",
                "Images",
                "GiftSets",
                imageName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return imageName;
        }
    }
}

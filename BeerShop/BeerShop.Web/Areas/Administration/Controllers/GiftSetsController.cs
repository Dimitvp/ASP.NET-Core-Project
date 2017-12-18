namespace BeerShop.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Models.GiftSets;
    using Services.Administration;
    using System;

    using static WebConstants;

    public class GiftSetsController : AdminBaseController
    {
        private const string GiftSetProduct = "GiftSet";

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

            var giftSetId = this.giftSets.Create(model.Name, model.Description, model.Quantity, model.Price);

            if (model.Image.HasValidImage())
            {
                var imageName = model.Image.SaveImage(giftSetId, GiftSetProduct, GiftSetsImagesPath);
                this.giftSets.SetImage(giftSetId, imageName);
            }

            this.TempData.AddSuccessMessage(string.Format(SuccessfullAdd, model.Name));

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

            if (model.Image.HasValidImage())
            {
                this.giftSets.SetImage(id, model.Image.SaveImage(id, GiftSetProduct, GiftSetsImagesPath));
            }

            var success = this.giftSets.Edit(id, model.Name, model.Description, model.Quantity, model.Price);

            if (!success)
            {
                return BadRequest();
            }

            this.TempData.AddWarningMessage(string.Format(SuccessfullEdit, model.Name));

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

            this.TempData.AddDangerMessage(SuccessfullDelete);

            return RedirectToAction(nameof(All));
        }
    }
}

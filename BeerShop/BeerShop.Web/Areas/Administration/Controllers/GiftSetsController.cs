namespace BeerShop.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Models.GiftSets;
    using Services.Administration;
    using System;

    public class GiftSetsController : AdminBaseController
    {
        private readonly IAdminGiftSetService giftSets;
        private readonly IMapper mapper;

        public GiftSetsController(IAdminGiftSetService giftSets, IMapper mapper)
        {
            this.giftSets = giftSets;
            this.mapper = mapper;
        }

        public IActionResult All (int page = WebConstants.DefaultPage)
        {
            var giftSets = this.giftSets.AllListing(page, WebConstants.PageSize);

            return View(new GiftSetPageListingViewModel
            {
                GiftSets = giftSets,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.giftSets.Total() / (double)WebConstants.PageSize)
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

            this.giftSets.Create(model.Name, model.Description, model.Quantity, model.Price);

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

            var success = this.giftSets.Edit(id, model.Name, model.Description, model.Quantity, model.Price);

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
    }
}

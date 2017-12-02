namespace BeerShop.Web.Areas.Shopping.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.GiftSets;
    using Services.Shopping;
    using System;

    using static WebConstants;

    public class GiftSetsController : BaseController
    {
        private readonly IShoppingGiftSetService giftSets;

        public GiftSetsController(IShoppingGiftSetService giftSets)
        {
            this.giftSets = giftSets;
        }

        public IActionResult All(int page = DefaultPage)
        {
            var giftSets = this.giftSets.All(page, PageSize);

            return View(new GiftSetPageListingViewModel
            {
                GiftSets = giftSets,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.giftSets.Total() / (double)PageSize)
            });
        }

        public IActionResult Details(int id)
        {
            var giftSet = this.giftSets.ById(id);

            if (giftSet == null)
            {
                return NotFound();
            }

            return View(giftSet);
        }
    }
}

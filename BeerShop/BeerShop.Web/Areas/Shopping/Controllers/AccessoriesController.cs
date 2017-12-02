namespace BeerShop.Web.Areas.Shopping.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Accessories;
    using Services.Shopping;
    using System;

    using static WebConstants;

    public class AccessoriesController : BaseController
    {
        private readonly IShoppingAccessoryService accessories;

        public AccessoriesController(IShoppingAccessoryService accessories)
        {
            this.accessories = accessories;
        }

        public IActionResult All(int page = DefaultPage)
        {
            var accessories = this.accessories.All(page, PageSize);

            return View(new AccessoryPageListingViewModel
            {
                Accessories = accessories,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.accessories.Total() / (double)PageSize)
            });
        }

        public IActionResult Details(int id)
        {
            var accessory = this.accessories.ById(id);

            if (accessories == null)
            {
                return NotFound();
            }

            return View(accessory);
        }
    }
}

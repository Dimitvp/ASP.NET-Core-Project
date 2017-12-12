namespace BeerShop.Web.Areas.Shopping.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Glasses;
    using Services.Shopping;
    using System;

    using static WebConstants;

    public class GlassesController : BaseController
    {
        private readonly IShoppingGlassService glasses;

        public GlassesController(IShoppingGlassService glasses)
        {
            this.glasses = glasses;
        }

        public IActionResult All(int page = DefaultPage)
        {
            var glasses = this.glasses.All(page, PageSize);

            return View(new GlassPageListingViewModel
            {
                Glasses = glasses,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.glasses.Total() / (double)PageSize)

            });
        }

        public IActionResult Details(int id)
        {
            var glass = this.glasses.ById(id);

            if (glass == null)
            {
                return NotFound();
            }

            return View(glass);
        }
    }
}

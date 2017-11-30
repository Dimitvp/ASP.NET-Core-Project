namespace BeerShop.Web.Areas.Shopping.Controllers
{
    using Services.Shopping;
    using Microsoft.AspNetCore.Mvc;

    [Area("Shopping")]
    public class BeersController : Controller
    {
        private readonly IShoppingBeerService beers;

        public BeersController(IShoppingBeerService beers)
        {
            this.beers = beers;
        }

        public IActionResult ByCountry(int id)
        {
            var beers = this.beers.BeersByCountry(id);

            return View(beers);
        }
    }
}

namespace BeerShop.Web.Controllers
{
    using BeerShop.Services;
    using Microsoft.AspNetCore.Mvc;

    public class BreweriesController : Controller
    {
        private readonly IBreweryService breweries;

        public BreweriesController(IBreweryService breweries)
        {
            this.breweries = breweries;
        }

        public IActionResult All()
        {
            return View();
        }
    }
}

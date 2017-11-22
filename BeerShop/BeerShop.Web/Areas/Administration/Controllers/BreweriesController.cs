namespace BeerShop.Web.Areas.Administration.Controllers
{
    using BeerShop.Services.Administration;
    using Microsoft.AspNetCore.Mvc;

    public class BreweriesController : AdminBaseController
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

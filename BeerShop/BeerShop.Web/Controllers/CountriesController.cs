namespace BeerShop.Web.Controllers
{
    using BeerShop.Models.Enums;
    using BeerShop.Services;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.Countries;

    public class CountriesController : Controller
    {
        private readonly ICountryService countries;

        public CountriesController(ICountryService countries)
        {
            this.countries = countries;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Log(LogType.Create)]
        public IActionResult Create(CountryFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            this.countries.Create(model.Name, (Continent)model.Continent);

            TempData["SuccessMessage"] = $"Succesfully added {model.Name}.";

            return RedirectToAction(nameof(Create));    
        }

        public IActionResult All()
        {
            return View(this.countries.All());
        }
    }
}

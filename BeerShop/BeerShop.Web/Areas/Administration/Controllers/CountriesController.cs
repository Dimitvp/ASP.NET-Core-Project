namespace BeerShop.Web.Areas.Administration.Controllers
{
    using BeerShop.Models.Enums;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.Countries;
    using Services.Administration;
    using System;

    using static WebConstants;

    public class CountriesController : AdminBaseController
    {
        private readonly IAdminCountryService countries;

        public CountriesController(IAdminCountryService countries)
        {
            this.countries = countries;
        }

        public IActionResult All(int page = DefaultPage)
        {
            var countries = this.countries.AllListing(page, PageSize);

            return View(new CountryPageListingViewModel
            {
                Countries = countries,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.countries.Total() / (double)PageSize)
            });
        }

        public IActionResult Create() => View();

        [HttpPost]
        [Log(LogType.Create)]
        public IActionResult Create(CountryFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            this.countries.Create(model.Name, (Continent)model.Continent);

            this.TempData.AddSuccessMessage(string.Format(SuccessfullAdd, model.Name));

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id)
        {
            var country = this.countries.ById(id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var success = this.countries.Delete(id);

            if (!success)
            {
                return BadRequest();
            }

            this.TempData.AddDangerMessage(SuccessfullDelete);

            return RedirectToAction(nameof(All));
        }
    }
}

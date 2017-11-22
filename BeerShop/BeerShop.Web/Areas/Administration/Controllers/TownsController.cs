namespace BeerShop.Web.Areas.Administration.Controllers
{
    using BeerShop.Models.Enums;
    using BeerShop.Services.Administration;
    using Models.Towns;
    using BeerShop.Web.Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Linq;

    public class TownsController : AdminBaseController
    {
        private readonly ITownService towns;
        private readonly ICountryService countries;

        public TownsController(
            ITownService towns,
            ICountryService countries)
        {
            this.towns = towns;
            this.countries = countries;
        }

        public IActionResult All()
            => View(this.towns.AllListing());


        public IActionResult Create()
        {
            return View(new TownFormModel
            {
                Countries = this.GetAllCountriesItems()
            });
        }

        [HttpPost]
        [Log(LogType.Create)]
        public IActionResult Create(TownFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Countries = this.GetAllCountriesItems();
                return View(model);
            }

            this.towns.Create(model.Name, model.ZipCode, model.CountryId);
            TempData["SuccessMessage"] = $"Successfully added town {model.Name}.";

            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var town = this.towns.ById(id);

            if (town == null)
            {
                return NotFound();
            }

            return View(new TownFormModel
            {
                Name = town.Name,
                ZipCode = town.ZipCode,
                CountryId = town.CountryId,
                Countries = this.GetAllCountriesItems()
            });
        }

        [HttpPost]
        [Log(LogType.Edit)]
        public IActionResult Edit(int id, TownFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Countries = this.GetAllCountriesItems();
                return View(model);
            }

            this.towns.Edit(id, model.Name, model.ZipCode, model.CountryId);
            TempData["WarningMessage"] = $"Successfully editted town {model.Name}";

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id, string name = null)
        {
            var town = this.towns.ById(id);

            return View(new TownFormModel
            {
                Name = town.Name,
                ZipCode = town.ZipCode,
                Countries = this.GetAllCountriesItems(),
                CountryId = town.CountryId
            });
        }

        [HttpPost]
        [Log(LogType.Delete)]
        public IActionResult Delete(int id)
        {
            this.towns.Delete(id);
            TempData["DangerMessage"] = "Delete was successfull.";

            return RedirectToAction(nameof(All));
        }

        private IEnumerable<SelectListItem> GetAllCountriesItems()
            => this.countries
                .All()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                });
    }
}

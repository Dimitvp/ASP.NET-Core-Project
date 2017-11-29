namespace BeerShop.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using BeerShop.Models.Enums;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Towns;
    using Services.Administration;
    using System.Collections.Generic;
    using System.Linq;

    public class TownsController : AdminBaseController
    {
        private readonly IAdminTownService towns;
        private readonly IAdminCountryService countries;
        private readonly IMapper mapper;

        public TownsController(
            IAdminTownService towns,
            IAdminCountryService countries,
            IMapper mapper)
        {
            this.towns = towns;
            this.countries = countries;
            this.mapper = mapper;
        }

        public IActionResult All()
            => View(this.towns.AllListing());


        public IActionResult Create()
        {
            return View(new TownFormViewModel
            {
                Countries = this.GetAllCountriesItems()
            });
        }

        [HttpPost]
        [Log(LogType.Create)]
        public IActionResult Create(TownFormViewModel model)
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

            var townFormMolde = this.mapper.Map<TownFormViewModel>(town);
            townFormMolde.Countries = this.GetAllCountriesItems();

            return View(townFormMolde);
        }

        [HttpPost]
        [Log(LogType.Edit)]
        public IActionResult Edit(int id, TownFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Countries = this.GetAllCountriesItems();
                return View(model);
            }

            var success = this.towns.Edit(id, model.Name, model.ZipCode, model.CountryId);

            if (!success)
            {
                return BadRequest();
            }

            TempData["WarningMessage"] = $"Successfully editted town {model.Name}";

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id, string name = null)
        {
            var town = this.towns.ById(id);

            var townFormMolde = this.mapper.Map<TownFormViewModel>(town);
            townFormMolde.Countries = this.GetAllCountriesItems();

            return View(townFormMolde);
        }

        [HttpPost]
        [Log(LogType.Delete)]
        public IActionResult Delete(int id)
        {
            var success = this.towns.Delete(id);

            if (!success)
            {
                return BadRequest();
            }
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

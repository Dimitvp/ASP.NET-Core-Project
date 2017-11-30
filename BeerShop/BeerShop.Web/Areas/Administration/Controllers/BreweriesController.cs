namespace BeerShop.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using BeerShop.Services.Administration;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Breweries;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BreweriesController : AdminBaseController
    {
        private readonly IAdminBreweryService breweries;
        private readonly IAdminCountryService countries;
        private readonly IMapper mapper;

        public BreweriesController(
            IAdminBreweryService breweries,
            IAdminCountryService countries,
            IMapper mapper)
        {
            this.breweries = breweries;
            this.countries = countries;
            this.mapper = mapper;
        }

        public IActionResult All(int page = WebConstants.DefaultPage)
        {
            var breweries = this.breweries.AllListing(page, WebConstants.PageSize);

            return View(new BreweryPageListingViewModel
            {
                Breweries = breweries,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.breweries.Total() / (double)WebConstants.PageSize)
            });
        }

        public IActionResult Create()
            => View(new BreweryFormViewModel
            {
                Countries = this.GetCountrySelectItems()
            });


        [HttpPost]
        public IActionResult Create(BreweryFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Countries = this.GetCountrySelectItems();
                return View(model);
            }

            this.breweries.Create(model.Name, model.Description, model.CountryId);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var brewery = this.breweries.ById(id);

            if (breweries == null)
            {
                return NotFound();
            }

            var beerFormModel = this.mapper.Map<BreweryFormViewModel>(brewery);
            beerFormModel.Countries = this.GetCountrySelectItems();

            return View(beerFormModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, BreweryFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Countries = this.GetCountrySelectItems();
                return View(model);
            }

            var success = this.breweries.Edit(id, model.Name, model.Description, model.CountryId);

            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id)
        {
            var brewery = this.breweries.ById(id);
            if (brewery == null)
            {
                return NotFound();
            }

            var beerFormModel = this.mapper.Map<BreweryFormViewModel>(brewery);
            beerFormModel.Countries = this.GetCountrySelectItems();

            return View(beerFormModel);
        }

        [HttpPost]
        public IActionResult Delete(int id, string empty)
        {
            var success = this.breweries.Delete(id);

            if (!success)
            {
                return BadRequest();
            }

            TempData["WarningMessage"] = "Successfully deleted a brewery";
            return RedirectToAction(nameof(All));
        }

        private IEnumerable<SelectListItem> GetCountrySelectItems()
            => this.countries.AllForSelect()
            .Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.Id.ToString()
            })
            .ToList();
    }
}
namespace BeerShop.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using BeerShop.Models.Enums;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Beers;
    using Services.Administration;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BeersController : AdminBaseController
    {
        private readonly IAdminBreweryService breweries;
        private readonly IAdminStyleService styles;
        private readonly IAdminBeerService beers;
        private readonly IMapper mapper;

        public BeersController(
            IAdminBreweryService breweries,
            IAdminStyleService styles,
            IAdminBeerService beers,
            IMapper mapper)
        {
            this.breweries = breweries;
            this.styles = styles;
            this.beers = beers;
            this.mapper = mapper;
        }

        public IActionResult All(string searchTerm, int page = WebConstants.DefaultPage)
        {
            var beers = this.beers.AllListing(searchTerm, page, WebConstants.PageSize);

            return View(new BeerPageListingViewModel
            {
                Beers = beers,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.beers.Total(searchTerm) / (double)WebConstants.PageSize),
                SearchTerm = searchTerm
            });
        }

        public IActionResult Create()
        {
            return View(new BeerFormViewModel
            {
                Styles = this.GetStylesListItems(),
                Breweries = this.GetBreweriesListItems()
            });
        }

        [HttpPost]
        [Log(LogType.Create)]
        public IActionResult Create(BeerFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Breweries = this.GetBreweriesListItems();
                model.Styles = this.GetStylesListItems();
                return View(model);
            }

            this.beers.Create(
                model.Name,
                model.Price,
                model.Quantity,
                model.Description,
                model.Alcohol,
                model.ServingTemp,
                model.Color,
                model.Bitterness,
                model.Density,
                model.Sweetness,
                model.Gasification,
                model.StyleId,
                model.BreweryId);

            TempData["SuccessMessage"] = $"Succesfully added beer {model.Name}.";

            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var beer = this.beers.ById(id);

            if (beer == null)
            {
                return NotFound();
            }

            var beerFormModel = this.mapper.Map<BeerFormViewModel>(beer);
            beerFormModel.Breweries = this.GetBreweriesListItems();
            beerFormModel.Styles = this.GetStylesListItems();

            return View(beerFormModel);
        }

        [HttpPost]
        [Log(LogType.Edit)]
        public IActionResult Edit(int id, BeerFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Breweries = this.GetBreweriesListItems();
                model.Styles = this.GetStylesListItems();
                return View(model);
            }

            var success = this.beers.Edit(
                                        id,
                                        model.Name,
                                        model.Price,
                                        model.Quantity,
                                        model.Description,
                                        model.Alcohol,
                                        model.ServingTemp,
                                        model.Color,
                                        model.Bitterness,
                                        model.Density,
                                        model.Sweetness,
                                        model.Gasification,
                                        model.StyleId,
                                        model.BreweryId);

            if (!success)
            {
                return BadRequest();
            }

            TempData["WarningMessage"] = $"Successfully editted beer {model.Name}";

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id, string name = null)
        {
            var beer = this.beers.ById(id);

            if (beer == null)
            {
                return NotFound();
            }

            var beerFormModel = this.mapper.Map<BeerFormViewModel>(beer);
            beerFormModel.Breweries = this.GetBreweriesListItems();
            beerFormModel.Styles = this.GetStylesListItems();

            return View(beerFormModel);
        }

        [HttpPost]
        [Log(LogType.Delete)]
        public IActionResult Delete(int id)
        {
            var success = this.beers.Delete(id);

            if (!success)
            {
                return BadRequest();
            }

            TempData["DangerMessage"] = "Delete was successfull.";

            return RedirectToAction(nameof(All));
        }

        private IEnumerable<SelectListItem> GetBreweriesListItems()
            => this.breweries.AllForSelect()
                .Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                });

        private IEnumerable<SelectListItem> GetStylesListItems()
            => this.styles.AllForSelect()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
    }
}

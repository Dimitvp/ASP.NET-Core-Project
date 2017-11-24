namespace BeerShop.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using BeerShop.Models.Enums;
    using BeerShop.Services.Administration;
    using BeerShop.Web.Areas.Administration.Models.Beers;
    using BeerShop.Web.Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult All(string searchTerm, int page = 1)
        {
            var beers = this.beers.AllListing(searchTerm, page, WebConstants.PageSize);

            return View(new BeerPageListingModel
            {
                Beers = beers,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.beers.Total(searchTerm) / (double)WebConstants.PageSize),
                SearchTerm = searchTerm
            });
        }

        public IActionResult Create()
        {
            return View(new BeerFormModel
            {
                Styles = this.GetStylesListItems(),
                Breweries = this.GetBreweriesListItems()
            });
        }

        [HttpPost]
        [Log(LogType.Create)]
        public IActionResult Create(BeerFormModel model)
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
                model.StyleId,
                model.BreweryId,
                model.Image);

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

            var beerFormModel = this.mapper.Map<BeerFormModel>(beer);
            beerFormModel.Breweries = this.GetBreweriesListItems();
            beerFormModel.Styles = this.GetStylesListItems();

            return View(beerFormModel);
        }

        [HttpPost]
        [Log(LogType.Edit)]
        public IActionResult Edit(int id, BeerFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Breweries = this.GetBreweriesListItems();
                model.Styles = this.GetStylesListItems();
                return View(model);
            }

            this.beers.Edit(
                    id,
                    model.Name,
                    model.Price,
                    model.Quantity,
                    model.StyleId,
                    model.BreweryId,
                    model.Image);

            TempData["WarningMessage"] = $"Successfully editted beer {model.Name}";

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id, string name = null)
        {
            var beer = this.beers.ById(id);

            var beerFormModel = this.mapper.Map<BeerFormModel>(beer);
            beerFormModel.Breweries = this.GetBreweriesListItems();
            beerFormModel.Styles = this.GetStylesListItems();

            return View(beerFormModel);
        }

        [HttpPost]
        [Log(LogType.Delete)]
        public IActionResult Delete(int id)
        {
            this.beers.Delete(id);
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

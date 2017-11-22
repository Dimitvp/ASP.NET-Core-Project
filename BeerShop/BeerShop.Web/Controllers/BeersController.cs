namespace BeerShop.Web.Controllers
{
    using BeerShop.Models.Enums;
    using BeerShop.Services;
    using BeerShop.Web.Infrastructure.Filters;
    using BeerShop.Web.Models.Beers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Linq;

    public class BeersController : Controller
    {
        private readonly IBreweryService breweries;
        private readonly IStyleService styles;
        private readonly IBeerService beers;

        public BeersController(
            IBreweryService breweries,
            IStyleService styles,
            IBeerService beers)
        {
            this.breweries = breweries;
            this.styles = styles;
            this.beers = beers;
        }

        public IActionResult All()
        {
            return View(this.beers.AllListing());
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

            this.beers.Create(model.Name, model.Price, model.Quantity, model.Description, model.StyleId, model.BreweryId);
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

            return View(new BeerFormModel
            {
                Name = beer.Name,
                Price = beer.Price,
                Quantity = beer.Quantity,
                Description = beer.Description,
                StyleId = beer.StyleId,
                BreweryId = beer.BreweryId,
                Breweries = this.GetBreweriesListItems(),
                Styles = this.GetStylesListItems()
            });
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
                    model.BreweryId);

            TempData["WarningMessage"] = $"Successfully editted beer {model.Name}";

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id, string name = null)
        {
            var beer = this.beers.ById(id);

            return View(new BeerFormModel
            {
                Name = beer.Name,
                Price = beer.Price,
                Quantity = beer.Quantity,
                StyleId = beer.StyleId,
                Description = beer.Description,
                BreweryId = beer.BreweryId,
                Breweries = this.GetBreweriesListItems(),
                Styles = this.GetStylesListItems()
            });
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

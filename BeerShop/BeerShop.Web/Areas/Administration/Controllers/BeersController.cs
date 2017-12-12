namespace BeerShop.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using BeerShop.Models.Enums;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Beers;
    using Services.Administration;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using static WebConstants;

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

        public IActionResult All(string searchTerm, int page = DefaultPage)
        {
            var beers = this.beers.AllListing(searchTerm, page, PageSize);

            return View(new BeerPageListingViewModel
            {
                Beers = beers,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.beers.Total(searchTerm) / (double)PageSize),
                SearchTerm = searchTerm
            });
        }

        public IActionResult Create()
            => View(new BeerFormViewModel
            {
                Styles = this.GetStylesListItems(),
                Breweries = this.GetBreweriesListItems()
            });

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

            var beerId = this.beers.Create(
                            model.Name,
                            model.Price,
                            model.Quantity,
                            model.Description,
                            model.Alcohol,
                            model.Volume,
                            model.ServingTemp,
                            model.Color,
                            model.Bitterness,
                            model.Density,
                            model.Sweetness,
                            model.Gasification,
                            model.StyleId,
                            model.BreweryId);

            if (this.HasValidImage(model.Image))
            {
                var imageName = this.SaveImage(beerId, model.Image);
                this.beers.SetImage(beerId, imageName);
            }

            TempData.AddSuccessMessage(string.Format(SuccessfullAdd, model.Name));

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

            if (this.HasValidImage(model.Image))
            {
                this.beers.SetImage(id, this.SaveImage(id, model.Image));
            }

            var success = this.beers.Edit(
                                        id,
                                        model.Name,
                                        model.Price,
                                        model.Quantity,
                                        model.Description,
                                        model.Alcohol,
                                        model.Volume,
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

            TempData.AddWarningMessage(string.Format(SuccessfullEdit, model.Name));

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

            TempData.AddDangerMessage(SuccessfullDelete);

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

        private string SaveImage(int beerId, IFormFile file)
        {
            var imageName = file.FileName.ToImageName(beerId);

            var filePath = Path
                .Combine(Directory.GetCurrentDirectory(),
                    BeersImagesPath,
                    imageName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return imageName;
        }

        private bool HasValidImage(IFormFile image)
            => image != null
                && image.Length <= ImageSize
                && (image.FileName.EndsWith(JpgFormat)
                    || image.FileName.EndsWith(PngFormat));
    }
}

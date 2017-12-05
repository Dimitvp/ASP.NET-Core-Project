namespace BeerShop.Web.Areas.Shopping.Controllers
{
    using Services.Shopping;
    using Microsoft.AspNetCore.Mvc;
    using BeerShop.Web.Areas.Shopping.Models.Beers;
    using System;

    using static WebConstants;
    using BeerShop.Models.Enums;

    public class BeersController : BaseController
    {
        private readonly IShoppingBeerService beers;

        public BeersController(IShoppingBeerService beers)
        {
            this.beers = beers;
        }

        public IActionResult All(int page = DefaultPage)
        {
            var beers = this.beers.All(page, PageSize);

            return View(new BeerListingViewModel
            {
                Beers = beers,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.beers.Total() / (double)PageSize)
            });
        }

        public IActionResult ByCountry(int id, string title, int page = DefaultPage)
        {
            var beers = this.beers.BeersByCountry(id, page, PageSize);

            return View(new BeersByCountryPageListingViewModel
            {
                Beers = beers,
                Country = title,
                CountryId = id,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.beers.TotalByCountry(id) / (double)PageSize)
            });
        }

        public IActionResult ByStyle(int id, string title, int page = DefaultPage)
        {
            var beers = this.beers.BeersByStyle(id, page, PageSize);

            return View(new BeersByStylePageListingViewModel
            {
                Beers = beers,
                Style = title,
                StyleId = id,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.beers.TotalByStyle(id) / (double)PageSize)
            });
        }

        public IActionResult ByColor(BeerColor id, int page = DefaultPage)
        {
            var beers = this.beers.BeersByColor(id, page, PageSize);

            return View(new BeersByColorPageListingViewModel
            {
                Beers = beers,
                Color = id,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.beers.TotalByColor(id) / (double)PageSize)
            });
        }

        public IActionResult Details(int id)
        {
            var beer = this.beers.ById(id);

            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }
    }
}

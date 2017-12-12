namespace BeerShop.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using BeerShop.Models.Enums;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.Styles;
    using Services.Administration;
    using System;

    using static WebConstants;

    public class StylesController : AdminBaseController
    {
        private readonly IAdminStyleService styles;
        private readonly IMapper mapper;

        public StylesController(IAdminStyleService styles, IMapper mapper)
        {
            this.styles = styles;
            this.mapper = mapper;
        }

        public IActionResult All(int page = DefaultPage)
        {
            var styles = this.styles.AllListing(page, PageSize);

            return View(new StylePageListingViewModel
            {
                Styles = styles,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.styles.Total() / (double)PageSize)
            });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Log(LogType.Create)]
        public IActionResult Create(StyleFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.styles.Create(model.Name);

            this.TempData.AddSuccessMessage(string.Format(SuccessfullAdd, model.Name));

            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var currentStyle = this.styles.ById(id);

            if (currentStyle == null)
            {
                return NotFound();
            }

            return View(this.mapper.Map<StyleFormViewModel>(currentStyle));
        }

        [HttpPost]
        [Log(LogType.Edit)]
        public IActionResult Edit(int id, StyleFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = this.styles.Edit(id,model.Name);

            if (!success)
            {
                return BadRequest();
            }

            this.TempData.AddWarningMessage(string.Format(SuccessfullEdit, model.Name));

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult Delete(int id, string name = null)
        {
            var currentStyle = this.styles.ById(id);

            if (currentStyle == null)
            {
                return NotFound();
            }

            return View(this.mapper.Map<StyleFormViewModel>(currentStyle));
        }

        [HttpPost]
        [Log(LogType.Delete)]
        public IActionResult Delete(int id)
        {
            var success = this.styles.Delete(id);

            if (!success)
            {
                return BadRequest();
            }

            this.TempData.AddDangerMessage(SuccessfullDelete);

            return RedirectToAction(nameof(All));
        }
    }
}

namespace BeerShop.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using BeerShop.Models.Enums;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.Styles;
    using Services.Administration;

    public class StylesController : AdminBaseController
    {
        private readonly IAdminStyleService styles;
        private readonly IMapper mapper;

        public StylesController(IAdminStyleService styles, IMapper mapper)
        {
            this.styles = styles;
            this.mapper = mapper;
        }

        public IActionResult All()
        {
            return View(this.styles.AllListing());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Log(LogType.Create)]
        public IActionResult Create(StyleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.styles.Create(model.Name);
            TempData["SuccessMessage"] = $"Succesfully added style \"{model.Name}\".";

            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var currentStyle = this.styles.ById(id);

            if (currentStyle == null)
            {
                return NotFound();
            }

            return View(this.mapper.Map<StyleFormModel>(currentStyle));
        }

        [HttpPost]
        [Log(LogType.Edit)]
        public IActionResult Edit(int id, StyleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.styles.Edit(
                    id,
                    model.Name);
            TempData["WarningMessage"] = $"Successfully editted {model.Name}";

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

            return View(this.mapper.Map<StyleFormModel>(currentStyle));
        }

        [HttpPost]
        [Log(LogType.Delete)]
        public IActionResult Delete(int id)
        {
            this.styles.Delete(id);
            TempData["DangerMessage"] = "Delete was successfull.";

            return RedirectToAction(nameof(All));
        }
    }
}

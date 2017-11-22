namespace BeerShop.Web.Areas.Administration.Controllers
{
    using BeerShop.Models.Enums;
    using BeerShop.Services.Administration;
    using Models.Styles;
    using BeerShop.Web.Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;

    public class StylesController : AdminBaseController
    {
        private readonly IStyleService styles;

        public StylesController(IStyleService styles)
        {
            this.styles = styles;
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

            this.styles.Create(model.Name, model.ServingTemp);
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

            return View(new StyleFormModel
            {
                Name = currentStyle.Name,
                ServingTemp = currentStyle.ServingTemp
            });
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
                    model.Name,
                    model.ServingTemp);
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

            return View(new StyleFormModel
            {
                Name = currentStyle.Name,
                ServingTemp = currentStyle.ServingTemp
            });
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

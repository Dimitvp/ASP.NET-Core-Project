namespace BeerShop.Web.Areas.Administration.Controllers
{
    using Services.Administration;
    using Microsoft.AspNetCore.Mvc;

    using static WebConstants;
    using BeerShop.Web.Areas.Administration.Models.Newsletter;
    using System;
    using BeerShop.Web.Infrastructure.Extensions;

    public class NewsletterController : AdminBaseController
    {
        private readonly IAdminNewsletterService newsletter;

        public NewsletterController(IAdminNewsletterService newsletter)
        {
            this.newsletter = newsletter;
        }

        public IActionResult All(int page = DefaultPage)
        {
            var emails = this.newsletter.All(page, PageSize);

            return View(new EmailPageListingViewModel
            {
                Emails = emails,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.newsletter.Total() / (double)PageSize)
            });
        }

        public IActionResult Delete(int id)
        {
            var subscriber = this.newsletter.ById(id);

            if (subscriber == null)
            {
                return NotFound();
            }

            return View(subscriber);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var success = this.newsletter.Delete(id);

            if (!success)
            {
                return BadRequest();
            }

            this.TempData.AddDangerMessage(SuccessfullDelete);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Download()
        {
            var emailList = this.newsletter.Emails();
            var fileName = "EmailList.txt";

            return File(emailList, "text/plain", fileName);
        }
    }
}

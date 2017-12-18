namespace BeerShop.Web.Areas.Administration.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Models.Newsletter;
    using Services.Administration;
    using System;

    using static WebConstants;


    public class NewsletterController : AdminBaseController
    {
        private const string FileName = "EmailList.txt";

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

            return File(emailList, "text/plain", FileName);
        }
    }
}

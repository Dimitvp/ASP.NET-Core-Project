namespace BeerShop.Web.Areas.Shopping.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Services.Shopping;

    using static WebConstants;

    public class NewsLetterController : BaseController
    {
        private readonly IShoppingNewsLetterService newsletter;

        public NewsLetterController(IShoppingNewsLetterService newsletter)
        {
            this.newsletter = newsletter;
        }

        [HttpPost]
        public IActionResult Subscribe(string email)
        {
            if (this.newsletter.Exists(email))
            {
                this.TempData.AddWarningMessage(string.Format(EmailAlreadySubscribed, email));

                return RedirectToAction("Index", "Home");
            }

            var result = this.newsletter.Create(email);

            if (!result)
            {
                this.TempData.AddWarningMessage(string.Format(InvalidEmailAddress, email));
            }
            else
            {
                this.TempData.AddSuccessMessage(SuccessfullSubscribtion);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

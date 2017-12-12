namespace BeerShop.Web.Areas.Administration.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Models.Messages;
    using Services.Administration;
    using System;

    using static WebConstants;

    public class MessagesController : AdminBaseController
    {
        private readonly IAdminMessageService messages;

        public MessagesController(IAdminMessageService messages)
        {
            this.messages = messages;
        }

        public IActionResult All(int page = DefaultPage)
        {
            var messsages = this.messages.AllListing(page, PageSize);

            return View(new MessagePageListingViewModel
            {
                Messages = messsages,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.messages.Total() / (double)PageSize)
            });
        }

        public IActionResult Details(int id)
        {
            var message = this.messages.ById(id);

            if (message == null)
            {
                return NotFound();    
            }

            this.messages.MarkAsRead(id);

            return View(message);
        }

        public IActionResult Delete(int id)
        {
            var success = this.messages.Delete(id);

            if (!success)
            {
                return BadRequest();
            }

            this.TempData.AddDangerMessage(SuccessfullDelete);

            return RedirectToAction(nameof(All));
        }
    }
}

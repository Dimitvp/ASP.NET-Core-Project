namespace BeerShop.Web.Areas.Administration.Controllers
{
    using Services.Administration;
    using Microsoft.AspNetCore.Mvc;
    using BeerShop.Web.Areas.Administration.Models.Messages;
    using System;

    public class MessagesController : AdminBaseController
    {
        private readonly IAdminMessageService messages;

        public MessagesController(IAdminMessageService messages)
        {
            this.messages = messages;
        }

        public IActionResult All(int page = 1)
        {
            var messsages = this.messages.AllListing(page, WebConstants.PageSize);

            return View(new MessagePageListingModel
            {
                Messages = messsages,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.messages.Total() / (double)WebConstants.PageSize)
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
            this.messages.Delete(id);

            TempData["DangerMessage"] = "Successfully deleted a message.";

            return RedirectToAction(nameof(All));
        }
    }
}

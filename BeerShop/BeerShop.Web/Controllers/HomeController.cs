namespace BeerShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.Messages;
    using Services;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly IMessageService messages;

        public HomeController(IMessageService messages)
        {
            this.messages = messages;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacts(MessageFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.messages.Create(model.Name, 
                model.Email, 
                model.Phone, 
                model.Subject, 
                model.Content);

            TempData["SuccessMessage"] = "Thank You for your message!";

            return RedirectToAction(nameof(Contacts));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

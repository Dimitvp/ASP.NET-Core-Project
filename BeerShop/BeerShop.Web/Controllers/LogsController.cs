namespace BeerShop.Web.Controllers
{
    using BeerShop.Services;
    using Microsoft.AspNetCore.Mvc;

    public class LogsController : Controller
    {
        private readonly ILogService logs;

        public LogsController(ILogService logs)
        {
            this.logs = logs;
        }

        public IActionResult All()
           => View(this.logs.AllListing());

        public IActionResult Clear()
        {
            this.logs.Clear();

            return RedirectToAction(nameof(All));
        }
    }
}

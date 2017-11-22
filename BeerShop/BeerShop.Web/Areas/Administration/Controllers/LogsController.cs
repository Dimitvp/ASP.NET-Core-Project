namespace BeerShop.Web.Areas.Administration.Controllers
{
    using BeerShop.Services.Administration;
    using Microsoft.AspNetCore.Mvc;

    public class LogsController : AdminBaseController
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

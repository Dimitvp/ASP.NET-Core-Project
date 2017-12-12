namespace BeerShop.Web.Areas.Administration.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Models.Logs;
    using Services.Administration;
    using System;

    using static WebConstants;

    public class LogsController : AdminBaseController
    {
        private readonly IAdminLogService logs;

        public LogsController(IAdminLogService logs)
        {
            this.logs = logs;
        }

        public IActionResult All(int page = DefaultPage)
        {
            var logs = this.logs.AllListing(page, PageSize);

            return View(new LogPageListingViewModel
            {
                Logs = logs,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.logs.Total() / (double)PageSize)
            });
        }

        public IActionResult Clear()
        {
            this.logs.Clear();

            this.TempData.AddWarningMessage(SuccessfullDelete);

            return RedirectToAction(nameof(All));
        }
    }
}

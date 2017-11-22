namespace BeerShop.Web.Infrastructure.Filters
{
    using BeerShop.Data;
    using BeerShop.Models;
    using BeerShop.Models.Enums;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class LogAttribute : ActionFilterAttribute
    {
        private readonly LogType LogType;

        public LogAttribute(LogType logType)
        {
            this.LogType = logType;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.ModelState.IsValid)
            {
                var username = context.HttpContext.User.Identity.Name;
                var controller = context.Controller.ToString();
                int indexOfLastDot = controller.LastIndexOf('.') + 1;
                controller = controller.Substring(indexOfLastDot).Replace("Controller", string.Empty);

                var db = context.HttpContext.RequestServices.GetService<BeerShopDbContext>();

                var log = new Log
                {
                    Username = username,
                    LogType = this.LogType,
                    Date = DateTime.UtcNow,
                    Table = controller
                };

                db.Logs.Add(log);
                db.SaveChanges();
            }
        }
    }
}

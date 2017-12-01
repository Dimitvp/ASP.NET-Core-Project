namespace BeerShop.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static WebConstants;

    [Area(AdminArea)]
    [Authorize(Roles = AdminRole)]
    public abstract class AdminBaseController : Controller
    {
    }
}

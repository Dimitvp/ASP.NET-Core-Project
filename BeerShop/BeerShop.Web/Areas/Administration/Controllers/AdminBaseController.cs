namespace BeerShop.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    [Authorize(Roles = WebConstants.AdminRole)]
    public abstract class AdminBaseController : Controller
    {
    }
}

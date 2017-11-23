namespace BeerShop.Web.Areas.Administration.Controllers
{
    using BeerShop.Models;
    using BeerShop.Services.Administration;
    using Models.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersController : AdminBaseController
    {
        private readonly IAdminService admins;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(
            IAdminService admins,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.admins = admins;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult All() => View(this.admins.AllUsers());

        public async Task<IActionResult> Details(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            var currentUser = this.admins.UserById(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await this.userManager.GetRolesAsync(user);
            currentUser.Roles = roles;

            return View(currentUser);
        }

        public IActionResult AddRole(string id)
        {
            var rolesSelectListItems = this.roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToList();

            return View(new AddRoleViewModel
            {
                UserId = id,
                Roles = rolesSelectListItems
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string id, string role)
        {
            var user = await this.userManager.FindByIdAsync(id);
            var isRoleExist = await this.roleManager.RoleExistsAsync(role);

            if (user == null || !isRoleExist)
            {
                return NotFound();
            }

            await this.userManager.AddToRoleAsync(user, role);

            return RedirectToAction(nameof(Details), new { id = id });
        }

        public async Task<IActionResult> ClearRoles(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await this.userManager.GetRolesAsync(user);
            await this.userManager.RemoveFromRolesAsync(user, roles);

            return RedirectToAction(nameof(Details), new { id = id });
        }
    }
}

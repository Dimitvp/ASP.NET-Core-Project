namespace BeerShop.Web.Areas.Administration.Controllers
{
    using BeerShop.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Users;
    using Services.Administration;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using static WebConstants;

    public class UsersController : AdminBaseController
    {
        private readonly IAdminUserService users;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(
            IAdminUserService admins,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.users = admins;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult All(string searchTerm, int page = 1)
        {
            var users = this.users.AllUsers(searchTerm, page, PageSize);

            return View(new UserPageListingViewModel
            {
                Users = users,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.users.Total(searchTerm) / (double)PageSize),
                SearchTerm = searchTerm
            });
        }
        public async Task<IActionResult> Details(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            var currentUser = this.users.UserById(id);
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

            this.TempData.AddSuccessMessage(string.Format(SuccessfullAddRoleToUser, role, user.UserName));

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

            this.TempData.AddDangerMessage(SuccessfullDelete);

            return RedirectToAction(nameof(Details), new { id = id });
        }
    }
}

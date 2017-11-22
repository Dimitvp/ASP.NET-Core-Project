namespace BeerShop.Web.Areas.Administration.Models.Users
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class AddRoleViewModel
    {
        public string UserId { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}

namespace BeerShop.Web.Areas.Administration.Controllers
{
    using BeerShop.Models.Enums;
    using Microsoft.AspNetCore.Mvc;
    using Models.Orders;
    using Services.Administration;
    using System;
    
    using static WebConstants;

    public class OrdersController : AdminBaseController
    {
        private readonly IAdminOrderService orders;

        public OrdersController(IAdminOrderService orders)
        {
            this.orders = orders;
        }

        public IActionResult All(int page = DefaultPage)
        {
            var orders = this.orders.AllListing(page, PageSize);

            return View(new OrderPageListingViewModel
            {
                Orders = orders,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.orders.Total() / (double)PageSize)
            });
        }

        public IActionResult Details(int id)
        {
            var order = this.orders.ById(id);

            if (order == null)
            {
                return NotFound();
            }
            
            return View(order);
        }

        [HttpPost]
        public IActionResult ChangeStatus(int id, OrderStatus status)
        {
            var success = this.orders.ChangeStatus(id, status);

            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}

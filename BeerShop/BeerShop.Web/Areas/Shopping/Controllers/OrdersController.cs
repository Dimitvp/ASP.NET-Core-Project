namespace BeerShop.Web.Areas.Shopping.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models.Orders;
    using Services.Shopping;
    using System.Collections.Generic;
    using System.Linq;

    public class OrdersController : BaseController
    {
        private readonly IShoppingBeerService beers;
        private readonly IShoppingAccessoryService accessories;
        private readonly IShoppingGiftSetService giftSets;
        private readonly IShoppingGlassService glasses;

        public OrdersController(
            IShoppingBeerService beers,
            IShoppingAccessoryService accessories,
            IShoppingGiftSetService giftSets,
            IShoppingGlassService glasses)
        {
            this.beers = beers;
            this.accessories = accessories;
            this.giftSets = giftSets;
            this.glasses = glasses;
        }

        public IActionResult AddToCart(int id, string product)
        {
            if (!this.beers.Exist(id))
            {
                return NotFound();
            }

            var shoppingCart = HttpContext.Session.GetShoppingCart();
            shoppingCart.Add(product, id);
            HttpContext.Session.Set(WebConstants.ShoppingCart, shoppingCart);

            return RedirectToAction(nameof(Cart));
        }

        public IActionResult Cart()
        {
            var shoppingCart = HttpContext.Session.GetShoppingCart();

            var allBeers = shoppingCart.Beers;
            var allAccessories = shoppingCart.Accessories;
            var allGiftSets = shoppingCart.GiftSets;
            var allGlasses = shoppingCart.Glasses;


            var beersToBuy = this.beers.ByIds(allBeers);
            var accessoriesToBuy = this.accessories.ByIds(allAccessories);
            var giftSetsToBuy = this.giftSets.ByIds(allGiftSets);
            var glassesToBuy = this.glasses.ByIds(allGlasses);

            return View(new ProductListingViewModel
            {
                Beers = beersToBuy,
                Accessories = accessoriesToBuy,
                GiftSets = giftSetsToBuy,
                Glasses = glassesToBuy,
                Total =
                    beersToBuy.Sum(b => b.Price * b.Quantity) +
                    accessoriesToBuy.Sum(a => a.Price * a.Quantity) +
                    giftSetsToBuy.Sum(gs => gs.Price * gs.Quantity) +
                    glassesToBuy.Sum(g => g.Price * g.Quantity)
            });
        }
    }
}

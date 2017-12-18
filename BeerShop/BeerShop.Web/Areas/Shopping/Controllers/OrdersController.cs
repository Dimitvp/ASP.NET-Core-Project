namespace BeerShop.Web.Areas.Shopping.Controllers
{
    using BeerShop.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Orders;
    using Services.Shopping;
    using System.Linq;
    using System.Threading.Tasks;

    using static WebConstants;

    public class OrdersController : BaseController
    {
        private const string AccessoryProduct = "accessory";
        private const string BeerProduct = "beer";
        private const string GiftSetProduct = "giftset";
        private const string GlassProduct = "glass";

        private readonly IShoppingAddressService addresses;
        private readonly IShoppingBeerService beers;
        private readonly IShoppingAccessoryService accessories;
        private readonly IShoppingGiftSetService giftSets;
        private readonly IShoppingGlassService glasses;
        private readonly IShoppingUserService users;
        private readonly IShoppingOrderService orders;
        private readonly UserManager<User> userManager;

        public OrdersController(
            IShoppingAddressService addresses,
            IShoppingBeerService beers,
            IShoppingAccessoryService accessories,
            IShoppingGiftSetService giftSets,
            IShoppingGlassService glasses,
            IShoppingUserService users,
            IShoppingOrderService orders,
            UserManager<User> userManager)
        {
            this.addresses = addresses;
            this.beers = beers;
            this.accessories = accessories;
            this.giftSets = giftSets;
            this.glasses = glasses;
            this.users = users;
            this.orders = orders;
            this.userManager = userManager;
        }

        public IActionResult AddToCart(int id, string product)
        {
            if (!this.IsProductExist(id, product))
            {
                return NotFound();
            }

            var shoppingCart = HttpContext.Session.GetShoppingCart();
            shoppingCart.Add(product, id);
            HttpContext.Session.Set(MyCart, shoppingCart);

            //this.TempData.AddSuccessMessage(string.Format(SuccessfullAddToCart, product));

            return PartialView("_ShoppingCart");
        }

        public IActionResult Cart()
        {
            var shoppingCart = HttpContext.Session.GetShoppingCart();

            return View(this.GetProductListingModel(shoppingCart));
        }

        public IActionResult Update(int id, int quantity, string product)
        {
            if (!this.IsProductExist(id, product))
            {
                return NotFound();
            }

            var shoppingCart = HttpContext.Session.GetShoppingCart();
            shoppingCart.Update(product, id, quantity);

            HttpContext.Session.Set(MyCart, shoppingCart);

            this.TempData.AddSuccessMessage(SuccessfullUpdateCart);

            return RedirectToAction(nameof(Cart));
        }

        public IActionResult Remove(int id, string product)
        {
            if (!this.IsProductExist(id, product))
            {
                return NotFound();
            }

            var shoppingCart = HttpContext.Session.GetShoppingCart();
            shoppingCart.Remove(product, id);

            HttpContext.Session.Set(MyCart, shoppingCart);

            this.TempData.AddDangerMessage(string.Format(SuccessfullRemoveProductFromCart, product));

            return RedirectToAction(nameof(Cart));
        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var shoppingCart = HttpContext.Session.GetShoppingCart();

            if (shoppingCart.TotalAdded() == 0)
            {
                return BadRequest();
            }

            var userId = this.userManager.GetUserId(User);
            var user = await this.userManager.FindByIdAsync(userId);
            var addressId = user.AddressId;

            var products = this.GetProductListingModel(shoppingCart);

            var address = this.addresses.ById(addressId);

            return View(new ProductsWithAddressViewModel
            {
                Accessories = products.Accessories,
                Beers = products.Beers,
                GiftSets = products.GiftSets,
                Glasses = products.Glasses,
                PhoneNumber = address.PhoneNumber,
                Street = address.Street,
                Town = address.Town,
                ZipCode = address.ZipCode,
                AddressId = address.Id,
                Total = products.Total
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(ProductsWithAddressViewModel model)
        {
            var shoppingCart = HttpContext.Session.GetShoppingCart();

            if (!ModelState.IsValid)
            {
                var products = this.GetProductListingModel(shoppingCart);
                model.Beers = products.Beers;
                model.Accessories = products.Accessories;
                model.GiftSets = products.GiftSets;
                model.Glasses = products.Glasses;
                model.Total = products.Total;

                return View(model);
            }

            var isAddressExist = this.addresses.Exists(
                                model.AddressId,
                                model.Town,
                                model.Street,
                                model.ZipCode,
                                model.PhoneNumber);
            if (!isAddressExist)
            {
                model.AddressId = this.addresses.Create(model.Town, model.Street, model.ZipCode, model.PhoneNumber);
            }

            var userId = this.userManager.GetUserId(User);

            var success = this.orders.Create(shoppingCart.Beers,
                                shoppingCart.Accessories,
                                shoppingCart.GiftSets,
                                shoppingCart.Glasses,
                                model.Total,
                                model.AddressId,
                                userId);

            if (!success)
            {
                return BadRequest();
            }

            shoppingCart.Clear();
            HttpContext.Session.Set(ShopArea, shoppingCart);

            this.TempData.AddSuccessMessage(PlacedOrder);

            return RedirectToAction("Index", "Home", new { area = ShopArea });
        }

        private bool IsProductExist(int id, string product)
            => (this.beers.Exists(id) && product == BeerProduct)
                   || (this.accessories.Exists(id) && product == AccessoryProduct)
                   || (this.giftSets.Exists(id) && product == GiftSetProduct)
                   || (this.glasses.Exists(id) && product == GlassProduct);

        private ProductListingViewModel GetProductListingModel(ShoppingCart shoppingCart)
        {
            var allBeers = shoppingCart.Beers;
            var allAccessories = shoppingCart.Accessories;
            var allGiftSets = shoppingCart.GiftSets;
            var allGlasses = shoppingCart.Glasses;


            var beersToBuy = this.beers.ByIds(allBeers);
            var accessoriesToBuy = this.accessories.ByIds(allAccessories);
            var giftSetsToBuy = this.giftSets.ByIds(allGiftSets);
            var glassesToBuy = this.glasses.ByIds(allGlasses);

            return (new ProductListingViewModel
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

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

    public class OrdersController : BaseController
    {
        private readonly IShoppingAddressService addresses;
        private readonly IShoppingBeerService beers;
        private readonly IShoppingAccessoryService accessories;
        private readonly IShoppingGiftSetService giftSets;
        private readonly IShoppingGlassService glasses;
        private readonly IShoppingUserService users;
        private readonly UserManager<User> userManager;

        public OrdersController(
            IShoppingAddressService addresses,
            IShoppingBeerService beers,
            IShoppingAccessoryService accessories,
            IShoppingGiftSetService giftSets,
            IShoppingGlassService glasses,
            IShoppingUserService users,
            UserManager<User> userManager)
        {
            this.addresses = addresses;
            this.beers = beers;
            this.accessories = accessories;
            this.giftSets = giftSets;
            this.glasses = glasses;
            this.users = users;
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
            HttpContext.Session.Set(WebConstants.ShoppingCart, shoppingCart);

            return RedirectToAction(nameof(Cart));
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

            HttpContext.Session.Set(WebConstants.ShoppingCart, shoppingCart);

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

            HttpContext.Session.Set(WebConstants.ShoppingCart, shoppingCart);

            return RedirectToAction(nameof(Cart));
        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var shoppingCart = HttpContext.Session.GetShoppingCart();

            var userId = this.userManager.GetUserId(User);
            var user = await this.userManager.FindByIdAsync(userId);
            var addressId = user.AddressId;

            var products = this.GetProductListingModel(shoppingCart);

            var address = this.addresses.ById(addressId);
            var produtsAddress = new ProductsWithAddressViewModel
            {
                Accessories = products.Accessories,
                Beers = products.Beers,
                GiftSets = products.GiftSets,
                Glasses = products.Glasses,
                PhoneNumber = user.PhoneNumber ?? string.Empty,
                Street = address.Street,
                Town = address.Town,
                ZipCode = address.ZipCode,
                Id = address.Id,
                Total = products.Total
            };

            return View(produtsAddress);
        }

        private bool IsProductExist(int id, string product)
            => this.beers.Exists(id) && product == "beer"
                   || this.accessories.Exists(id) && product == "accessory"
                   || this.giftSets.Exists(id) && product == "giftset"
                   || this.glasses.Exists(id) && product == "glass";

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

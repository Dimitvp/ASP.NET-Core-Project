namespace BeerShop.Web.Areas.Shopping.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Home;
    using Services.Shopping;
    
    public class HomeController : BaseController
    {
        private readonly IShoppingBeerService beers;
        private readonly IShoppingAccessoryService accessories;
        private readonly IShoppingGiftSetService giftSets;
        private readonly IShoppingGlassService glasses;
        private readonly IShoppingCountryService countries;
            
        public HomeController(
            IShoppingBeerService beers,
            IShoppingAccessoryService accessories,
            IShoppingGiftSetService giftSets,
            IShoppingGlassService glasses,
            IShoppingCountryService countries)
        {
            this.beers = beers;
            this.accessories = accessories;
            this.giftSets = giftSets;
            this.glasses = glasses;
            this.countries = countries;
        }

        public IActionResult Index()
        {
            return View(new ProductsListingViewModel
            {
                Beers = this.beers.LatestListing(),
                Accessories = this.accessories.LatestListing(),
                GiftSets = this.giftSets.LatestListing(),
                Glasses = this.glasses.LatestListing()
            });
        }
    }
}

namespace BeerShop.Web.Areas.Shopping.Models.Orders
{
    using Services.Shopping.Models.Accessories;
    using Services.Shopping.Models.Beers;
    using Services.Shopping.Models.GiftSets;
    using Services.Shopping.Models.Glasses;
    using System.Collections.Generic;

    public class ProductListingViewModel
    {
        public IEnumerable<BeerOrderServiceModel> Beers { get; set; } = new List<BeerOrderServiceModel>();

        public IEnumerable<AccessoryOrderServiceModel> Accessories { get; set; } = new List<AccessoryOrderServiceModel>();

        public IEnumerable<GiftSetOrderServiceModel> GiftSets { get; set; } = new List<GiftSetOrderServiceModel>();

        public IEnumerable<GlassOrderServiceModel> Glasses { get; set; } = new List<GlassOrderServiceModel>();

        public decimal Total { get; set; }
    }
}

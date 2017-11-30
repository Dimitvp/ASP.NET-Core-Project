namespace BeerShop.Services.Shopping.Models.GiftSets
{
    using BeerShop.Models.Products;
    using Common.Mapping;

    public class LatestGiftSetListingServiceModel : IMapFrom<GiftSet>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}

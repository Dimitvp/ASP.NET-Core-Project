namespace BeerShop.Services.Administration.Models.GiftSets
{
    using BeerShop.Models.Products;
    using Common.Mapping;

    public class GiftSetListingServiceModel : IMapFrom<GiftSet>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}

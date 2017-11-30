namespace BeerShop.Services.Administration.Models.GiftSets
{
    using BeerShop.Models.Products;
    using Common.Mapping;

    public class GiftSetEditServiceModel : IMapFrom<GiftSet>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}

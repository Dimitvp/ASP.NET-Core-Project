namespace BeerShop.Services.Administration.Models.Accessories
{
    using BeerShop.Models.Products;
    using Common.Mapping;

    public class AccessoryListingServiceModel : IMapFrom<Accessory>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}

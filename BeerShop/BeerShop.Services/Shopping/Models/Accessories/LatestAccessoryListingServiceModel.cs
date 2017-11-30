namespace BeerShop.Services.Shopping.Models.Accessories
{
    using BeerShop.Models.Products;
    using Common.Mapping;

    public class LatestAccessoryListingServiceModel : IMapFrom<Accessory>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}

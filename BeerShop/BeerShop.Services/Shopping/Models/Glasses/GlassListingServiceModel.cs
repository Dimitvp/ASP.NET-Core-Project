namespace BeerShop.Services.Shopping.Models.Glasses
{
    using BeerShop.Models.Products;
    using Common.Mapping;

    public class GlassListingServiceModel : IMapFrom<Glass>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }
    }
}

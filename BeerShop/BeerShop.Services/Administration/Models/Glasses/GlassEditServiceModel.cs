namespace BeerShop.Services.Administration.Models.Glasses
{
    using BeerShop.Models.Enums;
    using BeerShop.Models.Products;
    using Common.Mapping;

    public class GlassEditServiceModel : IMapFrom<Glass>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Volume { get; set; }

        public Material Material { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}

namespace BeerShop.Services.Administration.Models.Glasses
{
    using BeerShop.Models.Enums;
    using BeerShop.Models.Products;
    using Common.Mapping;

    public class GlassListingServiceModel : IMapFrom<Glass>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Volume { get; set; }
        
        public Material Material { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal Price { get; set; }
    }
}

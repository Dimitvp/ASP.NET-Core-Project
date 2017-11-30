namespace BeerShop.Services.Administration.Models.Accessories
{
    using BeerShop.Models.Products;
    using Common.Mapping;

    public class AccessoryEditServiceModel : IMapFrom<Accessory>
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal Price { get; set; }
    }
}

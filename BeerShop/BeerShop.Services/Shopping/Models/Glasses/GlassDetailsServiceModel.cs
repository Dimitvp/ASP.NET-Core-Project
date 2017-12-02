namespace BeerShop.Services.Shopping.Models.Glasses
{
    using BeerShop.Models.Enums;

    public class GlassDetailsServiceModel : GlassListingServiceModel
    {
        public string Description { get; set; }

        public int Volume { get; set; }

        public Material Material { get; set; }
    }
}

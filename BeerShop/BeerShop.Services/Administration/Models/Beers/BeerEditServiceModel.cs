namespace BeerShop.Services.Administration.Models.Beers
{
    using BeerShop.Common.Mapping;
    using BeerShop.Models.Enums;
    using BeerShop.Models.Products;

    public class BeerEditServiceModel : IMapFrom<Beer>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int StyleId { get; set; }

        public int BreweryId { get; set; }

        public string Description { get; set; }

        public double Alcohol { get; set; }

        public string ServingTemp { get; set; }

        public BeerColor Color { get; set; }

        public int Bitterness { get; set; }

        public int Density { get; set; }

        public int Sweetness { get; set; }

        public int Gasification { get; set; }
    }
}

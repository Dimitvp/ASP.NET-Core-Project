namespace BeerShop.Services.Administration.Models.Beers
{
    using BeerShop.Common.Mapping;
    using BeerShop.Models;

    public class BeerEditModel : IMapFrom<Beer>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int StyleId { get; set; }

        public int BreweryId { get; set; }

        public string Description { get; set; }
    }
}

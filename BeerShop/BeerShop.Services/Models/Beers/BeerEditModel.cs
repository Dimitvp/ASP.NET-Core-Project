namespace BeerShop.Services.Models.Beers
{
    public class BeerEditModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int StyleId { get; set; }

        public int BreweryId { get; set; }

        public string Description { get; set; }
    }
}

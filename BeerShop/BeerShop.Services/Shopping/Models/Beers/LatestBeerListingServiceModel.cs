namespace BeerShop.Services.Shopping.Models.Beers
{
    using BeerShop.Models.Products;
    using Common.Mapping;

    public class LatestBeerListingServiceModel : IMapFrom<Beer>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

    }
}

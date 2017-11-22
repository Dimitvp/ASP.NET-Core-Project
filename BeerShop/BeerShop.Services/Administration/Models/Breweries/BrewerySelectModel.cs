namespace BeerShop.Services.Administration.Models.Breweries
{
    using BeerShop.Common.Mapping;
    using BeerShop.Models;

    public class BrewerySelectModel : IMapFrom<Brewery>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

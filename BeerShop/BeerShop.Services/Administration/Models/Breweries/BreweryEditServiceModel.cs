namespace BeerShop.Services.Administration.Models.Breweries
{
    using BeerShop.Common.Mapping;
    using BeerShop.Models;

    public class BreweryEditServiceModel : IMapFrom<Brewery>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int CountryId { get; set; }
    }
}
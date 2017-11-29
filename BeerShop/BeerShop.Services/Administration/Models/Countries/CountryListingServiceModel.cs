namespace BeerShop.Services.Administration.Models.Countries
{
    using BeerShop.Common.Mapping;
    using BeerShop.Models;
    using BeerShop.Models.Enums;

    public class CountryListingServiceModel : IMapFrom<Country>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Continent Continent { get; set; }
    }
}

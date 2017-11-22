namespace BeerShop.Services.Models.Countries
{
    using BeerShop.Models.Enums;

    public class CountryListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Continent Continent { get; set; }
    }
}

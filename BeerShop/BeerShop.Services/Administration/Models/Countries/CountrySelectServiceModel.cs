namespace BeerShop.Services.Administration.Models.Countries
{
    using BeerShop.Models;
    using Common.Mapping;

    public class CountrySelectServiceModel : IMapFrom<Country>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

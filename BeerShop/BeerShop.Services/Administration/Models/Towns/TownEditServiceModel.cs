namespace BeerShop.Services.Administration.Models.Towns
{
    using BeerShop.Common.Mapping;
    using BeerShop.Models;

    public class TownEditServiceModel : IMapFrom<Town>
    {
        public string Name { get; set; }

        public string ZipCode { get; set; }

        public int CountryId { get; set; }
    }
}

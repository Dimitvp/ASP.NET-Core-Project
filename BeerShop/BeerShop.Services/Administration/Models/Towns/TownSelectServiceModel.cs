namespace BeerShop.Services.Administration.Models.Towns
{
    using BeerShop.Common.Mapping;
    using BeerShop.Models;

    public class TownSelectServiceModel : IMapFrom<Town>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
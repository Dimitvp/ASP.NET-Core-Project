namespace BeerShop.Services.Administration.Models.Breweries
{
    using AutoMapper;
    using BeerShop.Common.Mapping;
    using BeerShop.Models;

    public class BreweryListingServiceModel : BrewerySelectServiceModel, IHaveCustomMapping
    {
        public string Adress { get; set; }

        public string TownName { get; set; }

        public string Country { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Brewery, BreweryListingServiceModel>()
                .ForMember(blm => blm.TownName, cfg => cfg.MapFrom(b => b.Town.Name));

            mapper.CreateMap<Brewery, BreweryListingServiceModel>()
                .ForMember(blm => blm.Country, cfg => cfg.MapFrom(b => b.Town.Country.Name));
        }
    }
}
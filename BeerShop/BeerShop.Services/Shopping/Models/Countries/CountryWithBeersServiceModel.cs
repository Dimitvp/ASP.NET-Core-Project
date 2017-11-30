namespace BeerShop.Services.Shopping.Models.Countries
{
    using AutoMapper;
    using BeerShop.Models;
    using Common.Mapping;
    using System.Linq;

    public class CountryWithBeersServiceModel : IMapFrom<Country>, IHaveCustomMapping
    {
        public string Name { get; set; }

        public int Beers { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Country, CountryWithBeersServiceModel>()
                .ForMember(c => c.Beers, cfg => cfg.MapFrom(
                    c => c.Breweries.Sum(b => b.Beers.Count())));
        }
    }
}

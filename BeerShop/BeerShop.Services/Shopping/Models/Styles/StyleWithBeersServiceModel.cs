namespace BeerShop.Services.Shopping.Models.Styles
{
    using AutoMapper;
    using BeerShop.Models;
    using Common.Mapping;

    public class StyleWithBeersServiceModel : IMapFrom<Style>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Beers { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<Style, StyleWithBeersServiceModel>()
                .ForMember(sb => sb.Beers, cfg => cfg
                     .MapFrom(s => s.Beers.Count));
    }
}

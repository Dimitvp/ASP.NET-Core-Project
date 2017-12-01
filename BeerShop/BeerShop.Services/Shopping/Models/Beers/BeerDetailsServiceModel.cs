namespace BeerShop.Services.Shopping.Models.Beers
{
    using AutoMapper;
    using BeerShop.Models.Enums;
    using BeerShop.Models.Products;
    using Common.Mapping;

    public class BeerDetailsServiceModel : BeerListingServiceModel, IHaveCustomMapping
    {
        public string Description { get; set; }

        public double Alcohol { get; set; }

        public string ServingTemp { get; set; }

        public BeerColor Color { get; set; }

        public int Bitterness { get; set; }

        public int Density { get; set; }

        public int Sweetness { get; set; }

        public int Gasification { get; set; }

        public string Style { get; set; }

        public string Brewery { get; set; }

        public string Country { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<Beer, BeerDetailsServiceModel>()
                .ForMember(b => b.Style, cfg => cfg
                    .MapFrom(b => b.Style.Name))
                .ForMember(b => b.Brewery, cfg => cfg
                    .MapFrom(b => b.Brewery.Name))
                .ForMember(b => b.Country, cfg => cfg
                    .MapFrom(b => b.Brewery.Country.Name));
    }
}

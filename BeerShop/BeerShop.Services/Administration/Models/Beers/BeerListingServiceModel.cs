namespace BeerShop.Services.Administration.Models.Beers
{
    using AutoMapper;
    using BeerShop.Common.Mapping;
    using BeerShop.Models.Products;

    public class BeerListingServiceModel : IMapFrom<Beer>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Brewery { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Beer, BeerListingServiceModel>()
                .ForMember(b => b.Brewery, cfg => cfg.MapFrom(b => b.Brewery.Name));
        }
    }
}

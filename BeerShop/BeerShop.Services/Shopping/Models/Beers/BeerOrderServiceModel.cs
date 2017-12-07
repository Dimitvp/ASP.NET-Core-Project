namespace BeerShop.Services.Shopping.Models.Beers
{
    using AutoMapper;
    using BeerShop.Common.Mapping;
    using BeerShop.Models.Products;

    public class BeerOrderServiceModel : BeerListingServiceModel, IHaveCustomMapping
    {
        public string Description { get; set; }

        public int Quantity { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            var quantity = default(int);

            mapper.CreateMap<Beer, BeerOrderServiceModel>()
                  .ForMember(b => b.Quantity, cfg => cfg.MapFrom(b => quantity));
        }
    }
}

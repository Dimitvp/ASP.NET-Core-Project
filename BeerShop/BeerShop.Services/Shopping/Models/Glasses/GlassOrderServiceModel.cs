namespace BeerShop.Services.Shopping.Models.Glasses
{
    using AutoMapper;
    using BeerShop.Models.Products;
    using Common.Mapping;

    public class GlassOrderServiceModel : GlassListingServiceModel, IHaveCustomMapping
    {
        public string Description { get; set; }

        public int Quantity { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            var quantity = default(int);

            mapper.CreateMap<Glass, GlassOrderServiceModel>()
                  .ForMember(b => b.Quantity, cfg => cfg.MapFrom(b => quantity));
        }
    }
}

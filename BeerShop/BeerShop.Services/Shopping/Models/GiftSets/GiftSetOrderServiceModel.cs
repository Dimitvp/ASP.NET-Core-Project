namespace BeerShop.Services.Shopping.Models.GiftSets
{
    using AutoMapper;
    using BeerShop.Models.Products;
    using Common.Mapping;

    public class GiftSetOrderServiceModel : GiftSetDetailsServiceModel, IHaveCustomMapping
    {
        public int Quantity { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            var quantity = default(int);

            mapper.CreateMap<GiftSet, GiftSetOrderServiceModel>()
                  .ForMember(b => b.Quantity, cfg => cfg.MapFrom(b => quantity));
        }
    }
}

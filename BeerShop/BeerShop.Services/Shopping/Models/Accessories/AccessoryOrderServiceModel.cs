namespace BeerShop.Services.Shopping.Models.Accessories
{
    using AutoMapper;
    using BeerShop.Models.Products;
    using Common.Mapping;

    public class AccessoryOrderServiceModel : AccessoryDetailsServiceModel, IHaveCustomMapping
    {
        public int Quantity { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            var quantity = default(int);

            mapper.CreateMap<Accessory, AccessoryOrderServiceModel>()
                  .ForMember(b => b.Quantity, cfg => cfg.MapFrom(b => quantity));
        }
    }
}

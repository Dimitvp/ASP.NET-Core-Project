namespace BeerShop.Services.Administration.Models.Orders
{
    using AutoMapper;
    using BeerShop.Models;
    using Common.Mapping;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderDetailsServiceModel : OrderListingServiceModel, IHaveCustomMapping
    {
        public double Discount { get; set; }

        public User User { get; set; }

        public Address Address { get; set; }

        public decimal Price { get; set; }

        public IDictionary<string, int> Beers { get; set; }

        public IDictionary<string, int> GiftSets { get; set; }

        public IDictionary<string, int> Accessories { get; set; }

        public IDictionary<string, int> Glasses { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Order, OrderDetailsServiceModel>()
                .ForMember(o => o.Beers, cfg => cfg
                    .MapFrom(b => b.Beers.Select(t => new { t.Beer.Name, t.Quantity })
                        .ToDictionary(t => t.Name, t => t.Quantity)))
                 .ForMember(o => o.GiftSets, cfg => cfg
                    .MapFrom(gs => gs.GiftSets.Select(t => new { t.GiftSet.Name, t.Quantity })
                         .ToDictionary(t => t.Name, t => t.Quantity)))
                 .ForMember(o => o.Accessories, cfg => cfg
                    .MapFrom(a => a.Accessories.Select(t => new { t.Accessory.Name, t.Quantity })
                         .ToDictionary(t => t.Name, t => t.Quantity)))
                  .ForMember(o => o.Glasses, cfg => cfg
                    .MapFrom(g => g.Glasses.Select(t => new { t.Glass.Name, t.Quantity })
                         .ToDictionary(t => t.Name, t => t.Quantity)));
        }
    }
}

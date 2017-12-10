namespace BeerShop.Services.Models.Orders
{
    using AutoMapper;
    using BeerShop.Models;
    using BeerShop.Models.Enums;
    using Common.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderListingServiceModel : IMapFrom<Order>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public Address Address { get; set; }

        public DateTime Date { get; set; }

        public OrderStatus Status { get; set; }

        public decimal Price { get; set; }

        public IDictionary<string, int> Accessories { get; set; }

        public IDictionary<string, int> Beers { get; set; }

        public IDictionary<string, int> GiftSets { get; set; }

        public IDictionary<string, int> Glasses { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Order, OrderListingServiceModel>()
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

namespace BeerShop.Services.Administration.Models.Admins
{
    using BeerShop.Common.Mapping;
    using BeerShop.Models;
    using System;
    using System.Collections.Generic;
    using AutoMapper;

    public class UserDetailsModel : UserListingModel, IHaveCustomMapping
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public int OrdersCount { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastLogin { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsModel>()
                .ForMember(udm => udm.OrdersCount, cfg => cfg.MapFrom(u => u.Orders.Count));
        }
    }
}

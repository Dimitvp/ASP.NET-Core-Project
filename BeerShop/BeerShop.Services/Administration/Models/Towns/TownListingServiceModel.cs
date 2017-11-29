namespace BeerShop.Services.Administration.Models.Towns
{
    using AutoMapper;
    using BeerShop.Common.Mapping;
    using BeerShop.Models;

    public class TownListingServiceModel : TownEditServiceModel, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string CountryName { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Town, TownListingServiceModel>()
                .ForMember(tlm => tlm.CountryName, cfg => cfg.MapFrom(t => t.Country.Name));
        }
    }
}

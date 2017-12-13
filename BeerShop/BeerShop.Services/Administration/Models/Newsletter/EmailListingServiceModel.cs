namespace BeerShop.Services.Administration.Models.Newsletter
{
    using BeerShop.Models;
    using Common.Mapping;

    public class EmailListingServiceModel : IMapFrom<Subscription>
    {
        public int Id { get; set; }

        public string Email { get; set; }
    }
}

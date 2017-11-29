namespace BeerShop.Services.Administration.Models.Styles
{
    using BeerShop.Common.Mapping;
    using BeerShop.Models;

    public class StyleSelectServiceModel : IMapFrom<Style>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

namespace BeerShop.Services.Administration.Models.Styles
{
    using BeerShop.Common.Mapping;
    using BeerShop.Models;

    public class StyleEditModel : IMapFrom<Style>
    {
        public string Name { get; set; }

        public string ServingTemp { get; set; }
    }
}

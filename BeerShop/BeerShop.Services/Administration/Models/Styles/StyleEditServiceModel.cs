﻿namespace BeerShop.Services.Administration.Models.Styles
{
    using BeerShop.Common.Mapping;
    using BeerShop.Models;

    public class StyleEditServiceModel : IMapFrom<Style>
    {
        public string Name { get; set; }
    }
}

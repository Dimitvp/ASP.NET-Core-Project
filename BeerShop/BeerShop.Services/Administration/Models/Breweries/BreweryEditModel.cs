﻿namespace BeerShop.Services.Administration.Models.Breweries
{
    using BeerShop.Common.Mapping;
    using BeerShop.Models;

    public class BreweryEditModel : IMapFrom<Brewery>
    {
        public string Name { get; set; }

        public string Adress { get; set; }

        public int TownId { get; set; }
    }
}
namespace BeerShop.Web.Areas.Administration.Models.Breweries
{
    using BeerShop.Common.Mapping;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Administration.Models.Breweries;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static BeerShop.Models.ModelConstants;

    public class BreweryFormViewModel : IMapFrom<BreweryEditServiceModel>
    {

        [Required]
        [MaxLength(BreweryNameMaxLength)]
        [MinLength(BreweryNameMinLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(BreweryAddressMaxLength)]
        [MinLength(BreweryAddressMinLength)]
        public string Adress { get; set; }

        [Display(Name = "Town")]
        public int TownId { get; set; }

        public IEnumerable<SelectListItem> Towns { get; set; }
    }
}
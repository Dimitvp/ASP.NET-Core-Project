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
        public string Description { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}
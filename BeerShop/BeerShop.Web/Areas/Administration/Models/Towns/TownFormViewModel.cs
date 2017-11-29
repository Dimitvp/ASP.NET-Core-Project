namespace BeerShop.Web.Areas.Administration.Models.Towns
{
    using BeerShop.Common.Mapping;
    using BeerShop.Services.Administration.Models.Towns;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static BeerShop.Models.ModelConstants;

    public class TownFormViewModel : IMapFrom<TownEditServiceModel>
    {
        [Required]
        [MinLength(TownNameMinLength)]
        [MaxLength(TownNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(TownZipCodeMinLength)]
        [MaxLength(TownZipCodeMaxLength)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}

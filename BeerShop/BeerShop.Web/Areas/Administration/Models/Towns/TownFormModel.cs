using BeerShop.Models;

namespace BeerShop.Web.Areas.Administration.Models.Towns
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants;

    public class TownFormModel
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

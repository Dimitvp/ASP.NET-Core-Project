namespace BeerShop.Web.Models.Towns
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TownFormModel
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }
        
        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}

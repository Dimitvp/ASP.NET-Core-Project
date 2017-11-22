using BeerShop.Models;

namespace BeerShop.Web.Areas.Administration.Models.Countries
{
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants;

    public class CountryFormModel
    {
        [Required]
        [MinLength(CountryNameMinLength)]
        [MaxLength(CountryNameMaxLength)]
        public string Name { get; set; }

        public int Continent { get; set; }
    }
}

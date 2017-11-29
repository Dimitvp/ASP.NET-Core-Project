namespace BeerShop.Web.Areas.Administration.Models.Countries
{
    using System.ComponentModel.DataAnnotations;

    using static BeerShop.Models.ModelConstants;

    public class CountryFormViewModel
    {
        [Required]
        [MinLength(CountryNameMinLength)]
        [MaxLength(CountryNameMaxLength)]
        public string Name { get; set; }

        public int Continent { get; set; }
    }
}

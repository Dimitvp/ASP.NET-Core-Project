namespace BeerShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants;

    public class Town
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TownNameMaxLength)]
        [MinLength(TownNameMinLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(TownZipCodeMaxLength)]
        [MinLength(TownZipCodeMinLength)]
        public string ZipCode { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Brewery> Breweries { get; set; } = new HashSet<Brewery>();
    }
}

namespace BeerShop.Models
{
    using Products;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants;

    public class Brewery
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(BreweryNameMaxLength)]
        [MinLength(BreweryNameMinLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ProductDescriptionMaxLength)]
        [MinLength(ProductDescriptionMinLength)]
        public string Description { get; set; }
        
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Beer> Beers { get; set; } = new HashSet<Beer>();
    }
}

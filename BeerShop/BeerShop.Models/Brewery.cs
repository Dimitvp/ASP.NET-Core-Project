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
        [MaxLength(BreweryAddressMaxLength)]
        [MinLength(BreweryAddressMinLength)]
        public string Address { get; set; }

        public int TownId { get; set; }

        public Town Town { get; set; }

        public ICollection<Beer> Beers { get; set; } = new HashSet<Beer>();
    }
}

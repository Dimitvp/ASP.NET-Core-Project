namespace BeerShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants;

    public class Style
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(StyleNameMaxLength)]
        [MinLength(StyleNameMinLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ServingTempMaxLength)]
        public string ServingTemp { get; set; }

        public ICollection<Beer> Beers { get; set; } = new HashSet<Beer>();
    }
}
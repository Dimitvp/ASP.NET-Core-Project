namespace BeerShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants;

    public class Beer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(BeerNameMaxLength)]
        [MinLength(BeerNameMinLength)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(BeerDescriptionMaxLength)]
        [MinLength(BeerDescriptionMinLength)]
        public string Description { get; set; }

        public int StyleId { get; set; }

        public Style Style { get; set; }

        public int BreweryId { get; set; }

        public Brewery Brewery { get; set; }

        public ICollection<BeerOrder> Orders { get; set; } = new HashSet<BeerOrder>();
    }
}

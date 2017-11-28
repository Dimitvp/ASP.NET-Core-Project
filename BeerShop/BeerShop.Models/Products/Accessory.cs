namespace BeerShop.Models.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants;

    public class Accessory
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ProductNameMinLength)]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(ProductDescriptionMinLength)]
        [MaxLength(ProductDescriptionMaxLength)]
        public string Description { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public ICollection<AccessoryOrder> Orders { get; set; } = new HashSet<AccessoryOrder>();
    }
}

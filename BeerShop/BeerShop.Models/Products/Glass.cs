namespace BeerShop.Models.Products
{
    using Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants;

    public class Glass
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

        [Required]
        [Range(VolumeMinValue, VolumeMaxValue)]
        public int Volume { get; set; }

        [Required]
        public Material Material { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public string Image { get; set; }

        public ICollection<GlassOrder> Orders { get; set; } = new HashSet<GlassOrder>();
    }
}

namespace BeerShop.Models.Products
{
    using Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants;

    public class Beer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        [MinLength(ProductNameMinLength)]
        public string Name { get; set; }

        [Range(BeerCharacteristicsMinValue, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(BeerCharacteristicsMinValue, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(ProductDescriptionMaxLength)]
        [MinLength(ProductDescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        [Range(BeerCharacteristicsMinValue, BeerAlcoholMaxValue)]
        public double Alcohol { get; set; }

        [Required]
        [Range(VolumeMinValue,VolumeMaxValue)]
        public int Volume { get; set; }

        [Required]
        [MaxLength(ServingTempMaxLength)]
        public string ServingTemp { get; set; }

        public BeerColor Color { get; set; }

        [Required]
        [Range(BeerCharacteristicsMinValue, BeerCharacteristicsMaxValue)]
        public int Bitterness { get; set; }

        [Required]
        [Range(BeerCharacteristicsMinValue, BeerCharacteristicsMaxValue)]
        public int Density { get; set; }

        [Required]
        [Range(BeerCharacteristicsMinValue, BeerCharacteristicsMaxValue)]
        public int Sweetness { get; set; }

        [Required]
        [Range(BeerCharacteristicsMinValue, BeerCharacteristicsMaxValue)]
        public int Gasification { get; set; }

        public string Image { get; set; }

        public int StyleId { get; set; }

        public Style Style { get; set; }

        public int BreweryId { get; set; }

        public Brewery Brewery { get; set; }

        public ICollection<BeerOrder> Orders { get; set; } = new HashSet<BeerOrder>();
    }
}

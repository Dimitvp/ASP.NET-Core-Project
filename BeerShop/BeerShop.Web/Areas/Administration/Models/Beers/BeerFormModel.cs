namespace BeerShop.Web.Areas.Administration.Models.Beers
{
    using BeerShop.Models.Enums;
    using Common.Mapping;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Administration.Models.Beers;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static BeerShop.Models.ModelConstants;

    public class BeerFormModel : IMapFrom<BeerEditModel>
    {
        [Required]
        [MinLength(ProductNameMinLength)]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(ProductDescriptionMinLength)]
        [MaxLength(ProductDescriptionMaxLength)]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(BeerCharacteristicsMinValue, BeerAlcoholMaxValue)]
        public double Alcohol { get; set; }

        [Required]
        [Display(Name="Serving Temperature")]
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

        [Display(Name = "Style")]
        public int StyleId { get; set; }

        public IEnumerable<SelectListItem> Styles { get; set; }

        [Display(Name = "Brewery")]
        public int BreweryId { get; set; }

        public IEnumerable<SelectListItem> Breweries { get; set; }

    }
}

namespace BeerShop.Web.Areas.Administration.Models.Glasses
{
    using BeerShop.Common.Mapping;
    using BeerShop.Models.Enums;
    using Microsoft.AspNetCore.Http;
    using Services.Administration.Models.Glasses;
    using System.ComponentModel.DataAnnotations;

    using static BeerShop.Models.ModelConstants;

    public class GlassFormViewModel : IMapFrom<GlassEditServiceModel>
    {
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

        public IFormFile Image { get; set; }

    }
}

namespace BeerShop.Web.Areas.Administration.Models.Accessories
{
    using Common.Mapping;
    using Microsoft.AspNetCore.Http;
    using Services.Administration.Models.Accessories;
    using System.ComponentModel.DataAnnotations;

    using static BeerShop.Models.ModelConstants;

    public class AccessoryFormViewModel : IMapFrom<AccessoryEditServiceModel>
    {
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

        public IFormFile Image { get; set; }
    }
}

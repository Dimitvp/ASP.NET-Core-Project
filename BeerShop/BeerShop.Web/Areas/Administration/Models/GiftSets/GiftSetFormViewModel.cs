namespace BeerShop.Web.Areas.Administration.Models.GiftSets
{
    using Common.Mapping;
    using Microsoft.AspNetCore.Http;
    using Services.Administration.Models.GiftSets;
    using System.ComponentModel.DataAnnotations;

    using static BeerShop.Models.ModelConstants;

    public class GiftSetFormViewModel : IMapFrom<GiftSetEditServiceModel>
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

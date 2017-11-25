namespace BeerShop.Web.Areas.Administration.Models.Styles
{
    using BeerShop.Common.Mapping;
    using BeerShop.Services.Administration.Models.Styles;
    using System.ComponentModel.DataAnnotations;

    using static BeerShop.Models.ModelConstants;

    public class StyleFormModel : IMapFrom<StyleEditModel>
    {
        [Required]
        [MinLength(StyleNameMinLength)]
        [MaxLength(StyleNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ServingTempMaxLength)]
        [Display(Name = "Serving Temperature")]
        public string ServingTemp { get; set; }
    }
}

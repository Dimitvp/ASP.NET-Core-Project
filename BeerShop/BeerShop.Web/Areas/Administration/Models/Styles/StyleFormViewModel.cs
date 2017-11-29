namespace BeerShop.Web.Areas.Administration.Models.Styles
{
    using BeerShop.Common.Mapping;
    using BeerShop.Services.Administration.Models.Styles;
    using System.ComponentModel.DataAnnotations;

    using static BeerShop.Models.ModelConstants;

    public class StyleFormViewModel : IMapFrom<StyleEditServiceModel>
    {
        [Required]
        [MinLength(StyleNameMinLength)]
        [MaxLength(StyleNameMaxLength)]
        public string Name { get; set; }
    }
}

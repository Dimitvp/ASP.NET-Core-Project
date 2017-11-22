namespace BeerShop.Web.Models.Styles
{
    using System.ComponentModel.DataAnnotations;

    public class StyleFormModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Serving Temperature")]
        public string ServingTemp { get; set; }
    }
}

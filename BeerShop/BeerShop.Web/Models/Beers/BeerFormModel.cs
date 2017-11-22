namespace BeerShop.Web.Models.Beers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BeerFormModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Display(Name = "Style")]
        public int StyleId { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(6000)]
        public string Description { get; set; }

        public IEnumerable<SelectListItem> Styles { get; set; }

        [Display(Name = "Brewery")]
        public int BreweryId { get; set; }

        public IEnumerable<SelectListItem> Breweries { get; set; }
    }
}

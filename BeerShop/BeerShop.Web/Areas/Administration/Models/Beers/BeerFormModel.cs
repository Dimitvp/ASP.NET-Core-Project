using BeerShop.Models;

namespace BeerShop.Web.Areas.Administration.Models.Beers 
{
    using BeerShop.Common.Mapping;
    using BeerShop.Services.Administration.Models.Beers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants;

    public class BeerFormModel : IMapFrom<BeerEditModel>
    {
        [Required]
        [MinLength(BeerNameMinLength)]
        [MaxLength(BeerNameMaxLength)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Display(Name = "Style")]
        public int StyleId { get; set; }

        [Required]
        [MinLength(BeerDescriptionMinLength)]
        [MaxLength(BeerDescriptionMaxLength)]
        public string Description { get; set; }

        public IEnumerable<SelectListItem> Styles { get; set; }

        [Display(Name = "Brewery")]
        public int BreweryId { get; set; }

        public IEnumerable<SelectListItem> Breweries { get; set; }

        public IFormFile Image { get; set; }
    }
}

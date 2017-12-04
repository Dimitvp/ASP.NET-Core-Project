using System.ComponentModel.DataAnnotations;

namespace BeerShop.Web.Areas.Shopping.Models.Home
{
    public class SearchFormModel
    {
        public string SearchTerm { get; set; }

        [Display(Name = "Beers")]
        public bool SearchInBeers { get; set; } = true;

        [Display(Name = "Gift Sets")]
        public bool SearchInGiftSets { get; set; } = true;

        [Display(Name = "Glasses")]
        public bool SearchInGlasses { get; set; } = true;

        [Display(Name = "Accessories")]
        public bool SearchInAccessories { get; set; } = true;
    }
}

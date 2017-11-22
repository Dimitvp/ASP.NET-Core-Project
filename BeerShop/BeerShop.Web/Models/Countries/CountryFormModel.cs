namespace BeerShop.Web.Models.Countries
{
    using System.ComponentModel.DataAnnotations;

    public class CountryFormModel
    {
        [Required]
        public string Name { get; set; }
        
        public int Continent { get; set; }
    }
}

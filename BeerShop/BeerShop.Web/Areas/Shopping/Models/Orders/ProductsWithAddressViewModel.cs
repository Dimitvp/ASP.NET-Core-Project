namespace BeerShop.Web.Areas.Shopping.Models.Orders
{
    using System.ComponentModel.DataAnnotations;

    public class ProductsWithAddressViewModel : ProductListingViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}

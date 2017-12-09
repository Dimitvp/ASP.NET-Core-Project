namespace BeerShop.Web.Areas.Shopping.Models.Orders
{
    using System.ComponentModel.DataAnnotations;

    using static BeerShop.Models.ModelConstants;

    public class ProductsWithAddressViewModel : ProductListingViewModel
    {
        public int AddressId { get; set; }

        [Required]
        [MaxLength(TownNameMaxLength)]
        [MinLength(TownNameMinLength)]
        public string Town { get; set; }

        [Required]
        [MaxLength(UserAddressMaxLength)]
        [MinLength(UserAddressMinLength)]
        [Display(Name = "Address")]
        public string Street { get; set; }

        [Required]
        [MaxLength(TownZipCodeMaxLength)]
        [MinLength(TownZipCodeMinLength)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        [MinLength(PhoneNumberMinLength)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}

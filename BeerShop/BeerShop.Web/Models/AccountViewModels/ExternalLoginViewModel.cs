namespace BeerShop.Web.Models.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static BeerShop.Models.ModelConstants;
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string Username { get; set; }
        
        [Required]
        [Display(Name = "First Name")]
        [StringLength(UserFirstNameMaxLength, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = UserFirstNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(UserLastNameMaxLength, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = UserLastNameMinLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(TownNameMaxLength, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = TownNameMinLength)]
        public string Town { get; set; }

        [Required]
        [Display(Name = "Address")]
        [StringLength(UserAddressMaxLength, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = UserAddressMinLength)]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        [StringLength(TownZipCodeMaxLength, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = TownZipCodeMinLength)]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(PhoneNumberMaxLength, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; set; }
    }
}

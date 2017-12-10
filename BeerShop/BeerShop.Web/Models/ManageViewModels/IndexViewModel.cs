namespace BeerShop.Web.Models.ManageViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static BeerShop.Models.ModelConstants;

    public class IndexViewModel
    {
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Required]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

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

        public string StatusMessage { get; set; }
    }
}

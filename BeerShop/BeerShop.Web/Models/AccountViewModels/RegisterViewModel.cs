namespace BeerShop.Web.Models.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static BeerShop.Models.ModelConstants;

    public class RegisterViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(UserFirstNameMaxLength, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = UserFirstNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(UserLastNameMaxLength, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = UserLastNameMinLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(UserAddressMaxLength, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = UserAddressMinLength)]
        public string Address { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

namespace BeerShop.Web.Models.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;
    
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string Username { get; set; }
        

        [Required]
        //[StringLength(UserFirstNameMaxLength, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = UserFirstNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        //[StringLength(UserLastNameMaxLength, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = UserLastNameMinLength)]
        public string LastName { get; set; }

        [Required]
        //[StringLength(UserAddressMaxLength, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = UserAddressMinLength)]
        public string Address { get; set; }
    }
}

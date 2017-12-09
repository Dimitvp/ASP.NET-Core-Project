namespace BeerShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants;

    public class Address
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TownNameMaxLength)]
        [MinLength(TownNameMinLength)]
        public string Town { get; set; }

        [Required]
        [MaxLength(UserAddressMaxLength)]
        [MinLength(UserAddressMinLength)]
        public string Street { get; set; }

        [Required]
        [MaxLength(TownZipCodeMaxLength)]
        [MinLength(TownZipCodeMinLength)]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        [MinLength(PhoneNumberMinLength)]
        public string PhoneNumber { get; set; }

        public ICollection<User> Users { get; set; } = new HashSet<User>();

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}

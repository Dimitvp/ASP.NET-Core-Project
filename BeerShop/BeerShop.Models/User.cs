namespace BeerShop.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants;

    public class User : IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        [MinLength(UserFirstNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        [MinLength(UserLastNameMinLength)]
        public string LastName { get; set; }

        public int AddressId { get; set; }
        
        public Address Address { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastLogin { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}

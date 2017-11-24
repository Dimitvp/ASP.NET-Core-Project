namespace BeerShop.Web.Models.Messages
{
    using System.ComponentModel.DataAnnotations;

    public class MessageFormModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [Display(Name="Phone Number")]
        [MaxLength(50)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        [Display(Name="Message")]
        [MaxLength(3000)]
        public string Content { get; set; }
    }
}

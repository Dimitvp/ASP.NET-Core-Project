namespace BeerShop.Models
{
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants;

    public class Subscription
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }
    }
}

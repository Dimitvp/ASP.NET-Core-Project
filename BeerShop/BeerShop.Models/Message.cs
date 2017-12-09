namespace BeerShop.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants;

    public class Message
    {
        public int Id { get; set; }

        [Required]
        [MinLength(MessageNameMinLength)]
        [MaxLength(MessageNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(MessageEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [MinLength(PhoneNumberMinLength)]
        [MaxLength(PhoneNumberMaxLength)]
        public string Phone { get; set; }

        [Required]
        [MinLength(MessageSubjectMinLength)]
        [MaxLength(MessageSubjectMaxLength)]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Message")]
        [MinLength(MessageSubjectMinLength)]
        [MaxLength(MessageContentMaxLength)]
        public string Content { get; set; }

        public DateTime SentOn { get; set; }

        public bool IsRead { get; set; }
        
    }
}

namespace BeerShop.Web.Areas.Administration.Models.Carousel
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class CarouselUploadImageFormViewModel
    {
        [Display(Name = "First Image")]
        public IFormFile FirstImage { get; set; }

        [Display(Name = "Second Image")]
        public IFormFile SecondImage { get; set; }

        [Display(Name = "Third Image")]
        public IFormFile ThirdImage { get; set; }
    }
}

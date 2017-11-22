﻿namespace BeerShop.Models
{
    using BeerShop.Models.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants;

    public class Country
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(CountryNameMaxLength)]
        [MinLength(CountryNameMinLength)]
        public string Name { get; set; }

        [Required]
        public Continent Continent { get; set; }

        public ICollection<Town> Towns { get; set; } = new HashSet<Town>();
    }
}
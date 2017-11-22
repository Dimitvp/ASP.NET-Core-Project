﻿namespace BeerShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public int Id { get; set; }

        [Range(0, 100)]
        public double Discount { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<BeerOrder> Beers { get; set; } = new HashSet<BeerOrder>();
    }
}

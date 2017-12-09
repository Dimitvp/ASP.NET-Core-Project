namespace BeerShop.Models
{
    using Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public int Id { get; set; }

        [Range(0, 100)]
        public double Discount { get; set; }
        
        public DateTime Date { get; set; }

        public OrderStatus Status { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public decimal Price { get; set; }

        public ICollection<BeerOrder> Beers { get; set; } = new HashSet<BeerOrder>();

        public ICollection<GiftSetOrder> GiftSets { get; set; } = new HashSet<GiftSetOrder>();

        public ICollection<AccessoryOrder> Accessories { get; set; } = new HashSet<AccessoryOrder>();

        public ICollection<GlassOrder> Glasses { get; set; } = new HashSet<GlassOrder>();
    }
}

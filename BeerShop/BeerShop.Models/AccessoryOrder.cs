namespace BeerShop.Models
{
    using Products;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AccessoryOrders")]
    public class AccessoryOrder
    {
        public int AccessoryId { get; set; }

        public Accessory Accessory { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int Quantity { get; set; }
    }
}

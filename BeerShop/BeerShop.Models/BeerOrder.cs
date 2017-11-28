namespace BeerShop.Models
{
    using Products;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("BeerOrders")]
    public class BeerOrder
    {
        public int BeerId { get; set; }

        public Beer Beer { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int Quantity { get; set; }
    }
}

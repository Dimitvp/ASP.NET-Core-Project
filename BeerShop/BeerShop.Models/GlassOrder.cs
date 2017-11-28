namespace BeerShop.Models
{
    using Products;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GlassOrders")]
    public class GlassOrder
    {
        public int GlassId { get; set; }

        public Glass Glass { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int Quantity { get; set; }
    }
}

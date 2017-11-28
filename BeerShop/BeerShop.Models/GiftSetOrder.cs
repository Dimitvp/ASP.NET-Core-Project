namespace BeerShop.Models
{
    using Products;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GiftSetOrders")]
    public class GiftSetOrder
    {
        public int GiftSetId { get; set; }

        public GiftSet GiftSet { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int Quantity { get; set; }
    }
}

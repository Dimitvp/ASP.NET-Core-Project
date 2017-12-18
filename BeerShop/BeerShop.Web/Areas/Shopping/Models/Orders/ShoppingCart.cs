namespace BeerShop.Web.Areas.Shopping.Models.Orders
{
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingCart
    {
        private const string AccessoryProduct = "accessory";
        private const string BeerProduct = "beer";
        private const string GiftSetProduct = "giftset";
        private const string GlassProduct = "glass";

        private readonly IDictionary<int, int> beerIds;
        private readonly IDictionary<int, int> accessoryIds;
        private readonly IDictionary<int, int> giftSetsIds;
        private readonly IDictionary<int, int> glassIds;

        public ShoppingCart()
        {
            this.accessoryIds = Accessories;
            this.beerIds = Beers;
            this.giftSetsIds = GiftSets;
            this.glassIds = Glasses;
        }

        public IDictionary<int, int> Beers { get; set; } = new Dictionary<int, int>();

        public IDictionary<int, int> Accessories { get; set; } = new Dictionary<int, int>();

        public IDictionary<int, int> GiftSets { get; set; } = new Dictionary<int, int>();

        public IDictionary<int, int> Glasses { get; set; } = new Dictionary<int, int>();

        public void Add(string productType, int id, int quantity = 1)
        {
            switch (productType.ToLower())
            {
                case AccessoryProduct:
                    if (!this.Accessories.ContainsKey(id))
                    {
                        this.Accessories.Add(id, quantity);
                    }
                    else
                    {
                        this.Accessories[id]++;
                    }
                    break;
                case BeerProduct:
                    if (!this.Beers.ContainsKey(id))
                    {
                        this.Beers.Add(id, quantity);
                    }
                    else
                    {
                        this.Beers[id]++;
                    }
                    break;
                case GiftSetProduct:
                    if (!this.GiftSets.ContainsKey(id))
                    {
                        this.GiftSets.Add(id, quantity);
                    }
                    else
                    {
                        this.GiftSets[id]++;
                    }
                    break;
                case GlassProduct:
                    if (!this.Glasses.ContainsKey(id))
                    {
                        this.Glasses.Add(id, quantity);
                    }
                    else
                    {
                        this.Glasses[id]++;
                    }
                    break;
                default:
                    break;
            }
        }

        public void Update(string productType, int id, int quantity)
        {
            switch (productType.ToLower())
            {
                case AccessoryProduct:
                    this.Accessories[id] = quantity;
                    if (this.Accessories[id] <= 0)
                    {
                        this.Accessories.Remove(id);
                    }
                    break;
                case BeerProduct:
                    this.Beers[id] = quantity;
                    if (this.Beers[id] <= 0)
                    {
                        this.Beers.Remove(id);
                    }
                    break;
                case GiftSetProduct:
                    this.GiftSets[id] = quantity;
                    if (this.GiftSets[id] <= 0)
                    {
                        this.GiftSets.Remove(id);
                    }
                    break;
                case GlassProduct:
                    this.Glasses[id] = quantity;
                    if (this.Glasses[id] <= 0)
                    {
                        this.Glasses.Remove(id);
                    }
                    break;
                default:
                    break;
            }
        }

        public void Remove(string productType, int id)
        {
            switch (productType.ToLower())
            {
                case AccessoryProduct:
                    this.Accessories.Remove(id);
                    break;
                case BeerProduct:
                    this.Beers.Remove(id);
                    break;
                case GiftSetProduct:
                    this.GiftSets.Remove(id);
                    break;
                case GlassProduct:
                    this.glassIds.Remove(id);
                    break;
                default:
                    break;
            }
        }

        public int TotalAdded()
        {
            var beers = this.Beers.Values.Sum();
            var accessories = this.Accessories.Values.Sum();
            var giftsets = this.GiftSets.Values.Sum();
            var glasses = this.Glasses.Values.Sum();

            var all = beers + accessories + giftsets + glasses;

            return all;
        }

        public void Clear()
        {
            this.Beers.Clear();
            this.Accessories.Clear();
            this.GiftSets.Clear();
            this.Glasses.Clear();
        }
    }
}

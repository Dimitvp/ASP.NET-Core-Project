namespace BeerShop.Web.Areas.Shopping.Models.Orders
{
    using System.Collections.Generic;

    public class ShoppingCart
    {
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
                case "accessory":
                    if (!this.Accessories.ContainsKey(id))
                    {
                        this.Accessories.Add(id, quantity);
                    }
                    else
                    {
                        this.Accessories[id]++;
                    }
                    break;
                case "beer":
                    if (!this.Beers.ContainsKey(id))
                    {
                        this.Beers.Add(id, quantity);
                    }
                    else
                    {
                        this.Beers[id]++;
                    }
                    break;
                case "giftset":
                    if (!this.GiftSets.ContainsKey(id))
                    {
                        this.GiftSets.Add(id, quantity);
                    }
                    else
                    {
                        this.GiftSets[id]++;
                    }
                    break;
                case "glass":
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
                case "accessory":
                    this.Accessories[id] = quantity;
                    if (this.Accessories[id] <= 0)
                    {
                        this.Accessories.Remove(id);
                    }
                    break;
                case "beer":
                    this.Beers[id] = quantity;
                    if (this.Beers[id] <= 0)
                    {
                        this.Beers.Remove(id);
                    }
                    break;
                case "giftset":
                    this.GiftSets[id] = quantity;
                    if (this.GiftSets[id] <= 0)
                    {
                        this.GiftSets.Remove(id);
                    }
                    break;
                case "glass":
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
                case "accessory":
                    this.Accessories.Remove(id);
                    break;
                case "beer":
                    this.Beers.Remove(id);
                    break;
                case "giftset":
                    this.GiftSets.Remove(id);
                    break;
                case "glass":
                    this.glassIds.Remove(id);
                    break;
                default:
                    break;
            }
        }

        public int TotalAdded()
        {
            var beers = this.Beers.Count;
            var accessories = this.Accessories.Count;
            var giftsets = this.GiftSets.Count;
            var glasses = this.Glasses.Count;

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

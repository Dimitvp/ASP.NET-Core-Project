namespace BeerShop.Services.Shopping.Implementations
{
    using BeerShop.Models;
    using BeerShop.Models.Enums;
    using Data;
    using System;
    using System.Collections.Generic;

    public class ShoppingOrderService : IShoppingOrderService
    {
        private readonly BeerShopDbContext db;

        public ShoppingOrderService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public bool Create(IDictionary<int, int> beers, IDictionary<int, int> accessories, IDictionary<int, int> giftSets, IDictionary<int, int> glasses, decimal totalPrice, int addressId, string userId)
        {
            var address = this.db.Addresses.Find(addressId);

            if (address == null)
            {
                return false;
            }

            var user = this.db.Users.Find(userId);

            if (user == null)
            {
                return false;
            }

            var order = new Order
            {
                Address = address,
                User = user,
                Status = OrderStatus.Processing,
                Date = DateTime.UtcNow,
                Price = totalPrice
            };

            this.db.Orders.Add(order);
            this.db.SaveChanges();

            foreach (var beer in beers)
            {
                var beerOrder = new BeerOrder
                {
                    BeerId = beer.Key,
                    Order = order,
                    Quantity = beer.Value
                };

                this.db.BeerOrders.Add(beerOrder);
            }

            foreach (var accessory in accessories)
            {
                var accessoryOrder = new AccessoryOrder
                {
                    AccessoryId = accessory.Key,
                    Order = order,
                    Quantity = accessory.Value
                };

                this.db.AccessoryOrders.Add(accessoryOrder);
            }

            foreach (var giftSet in giftSets)
            {
                var giftSetOrder = new GiftSetOrder
                {
                    GiftSetId = giftSet.Key,
                    Order = order,
                    Quantity = giftSet.Value
                };

                this.db.GiftSetOrders.Add(giftSetOrder);
            }

            foreach (var glass in glasses)
            {
                var glassOrder = new GlassOrder
                {
                    GlassId = glass.Key,
                    Order = order,
                    Quantity = glass.Value
                };

                this.db.GlassOrders.Add(glassOrder);
            }

            this.db.SaveChanges();

            return true;
        }
    }
}

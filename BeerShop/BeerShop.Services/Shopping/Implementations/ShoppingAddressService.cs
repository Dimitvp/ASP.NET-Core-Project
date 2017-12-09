namespace BeerShop.Services.Shopping.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BeerShop.Models;
    using Data;
    using Models.Addresses;
    using System.Linq;

    public class ShoppingAddressService : IShoppingAddressService
    {
        private readonly BeerShopDbContext db;

        public ShoppingAddressService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public int Create(string town, string street, string zipCode, string phoneNumber)
        {
            var address = new Address
            {
                Town = town,
                Street = street,
                ZipCode = zipCode,
                PhoneNumber = phoneNumber
            };

            this.db.Addresses.Add(address);
            this.db.SaveChanges();

            return address.Id;
        }

        public AddressDetailsServiceModel ById(int id)
            => this.db.Addresses
                .Where(a => a.Id == id)
                .ProjectTo<AddressDetailsServiceModel>()
                .FirstOrDefault();

        public bool Exists(int id, string town, string street, string zipcode, string phoneNumber)
        {
            var address = this.db.Addresses.Find(id);

            if (address == null)
            {
                return false;
            }

            if (address.Town != town 
                || address.Street != street 
                || address.ZipCode != zipcode 
                || address.PhoneNumber != phoneNumber)
            {
                return false;
            }

            return true;
        }
    }
}

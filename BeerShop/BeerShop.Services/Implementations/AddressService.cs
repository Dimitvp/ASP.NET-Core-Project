namespace BeerShop.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models.Addresses;
    using System.Linq;

    public class AddressService : IAddressService
    {
        private readonly BeerShopDbContext db;

        public AddressService(BeerShopDbContext db)
        {
            this.db = db;
        }

        public AddressDetailsServiceModel ById(int id)
            => this.db.Addresses
                .Where(a => a.Id == id)
                .ProjectTo<AddressDetailsServiceModel>()
                .FirstOrDefault();

        public bool Update(int id, string town, string street, string zipCode, string phoneNumber)
        {
            var address = this.db.Addresses.Find(id);

            if (address == null)
            {
                return false;
            }

            address.Town = town;
            address.Street = street;
            address.ZipCode = zipCode;
            address.PhoneNumber = phoneNumber;

            this.db.SaveChanges();

            return true;
        }
    }
}

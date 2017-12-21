namespace BeerShop.Tests
{
    using AutoMapper;
    using BeerShop.Data;
    using BeerShop.Web.Infrastructure.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class Tests
    {
        private static bool testInitialized = false;

        public static void Initialize()
        {
            if (!testInitialized)
            {
                Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
                testInitialized = true;
            }
        }

        public static BeerShopDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<BeerShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new BeerShopDbContext(dbOptions);
        }
    }
}

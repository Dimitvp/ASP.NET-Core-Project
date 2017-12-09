namespace BeerShop.Data
{
    using Models;
    using Models.Products;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class BeerShopDbContext : IdentityDbContext<User>
    {
        public BeerShopDbContext(DbContextOptions<BeerShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Accessory> Accessories { get; set; }

        public DbSet<AccessoryOrder> AccessoryOrders { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Beer> Beers { get; set; }

        public DbSet<BeerOrder> BeerOrders { get; set; }

        public DbSet<Brewery> Breweries { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<GiftSet> GiftSets { get; set; }

        public DbSet<GiftSetOrder> GiftSetOrders { get; set; }

        public DbSet<Glass> Glasses { get; set; }

        public DbSet<GlassOrder> GlassOrders { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Style> Styles { get; set; }

        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GlassOrder>()
                .HasKey(go => new { go.GlassId, go.OrderId });

            builder.Entity<Glass>()
                .HasMany(g => g.Orders)
                .WithOne(o => o.Glass)
                .HasForeignKey(o => o.GlassId);

            builder.Entity<Order>()
                .HasMany(o => o.Glasses)
                .WithOne(g => g.Order)
                .HasForeignKey(g => g.OrderId);

            builder.Entity<AccessoryOrder>()
                .HasKey(ao => new { ao.AccessoryId, ao.OrderId });

            builder.Entity<Accessory>()
                .HasMany(a => a.Orders)
                .WithOne(o => o.Accessory)
                .HasForeignKey(o => o.AccessoryId);

            builder.Entity<Order>()
                .HasMany(o => o.Accessories)
                .WithOne(a => a.Order)
                .HasForeignKey(a => a.OrderId);

            builder.Entity<GiftSetOrder>()
                .HasKey(gso => new { gso.GiftSetId, gso.OrderId });

            builder.Entity<GiftSet>()
                .HasMany(gs => gs.Orders)
                .WithOne(o => o.GiftSet)
                .HasForeignKey(o => o.GiftSetId);

            builder.Entity<Order>()
                .HasMany(o => o.GiftSets)
                .WithOne(gs => gs.Order)
                .HasForeignKey(gs => gs.OrderId);

            builder.Entity<BeerOrder>()
                .HasKey(bs => new { bs.BeerId, bs.OrderId });

            builder.Entity<Beer>()
                .HasOne(b => b.Style)
                .WithMany(s => s.Beers)
                .HasForeignKey(b => b.StyleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Beer>()
                .HasOne(b => b.Brewery)
                .WithMany(br => br.Beers)
                .HasForeignKey(b => b.BreweryId);

            builder.Entity<Beer>()
                .HasMany(b => b.Orders)
                .WithOne(s => s.Beer)
                .HasForeignKey(s => s.BeerId);

            builder.Entity<Order>()
                .HasMany(s => s.Beers)
                .WithOne(b => b.Order)
                .HasForeignKey(b => b.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Brewery>()
                .HasOne(b => b.Country)
                .WithMany(t => t.Breweries)
                .HasForeignKey(b => b.CountryId);

            builder.Entity<User>()
                .HasMany(c => c.Orders)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);

            builder.Entity<Address>()
                .HasMany(a => a.Users)
                .WithOne(u => u.Address)
                .HasForeignKey(u => u.AddressId);

            builder.Entity<Address>()
                .HasMany(a => a.Orders)
                .WithOne(o => o.Address)
                .HasForeignKey(u => u.AddressId);

            base.OnModelCreating(builder);
        }
    }
}

namespace BeerShop.Data
{
    using BeerShop.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class BeerShopDbContext : IdentityDbContext<User>
    {
        public BeerShopDbContext(DbContextOptions<BeerShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Beer> Beers { get; set; }

        public DbSet<Brewery> Breweries { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Style> Styles { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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
                .HasOne(b => b.Town)
                .WithMany(t => t.Breweries)
                .HasForeignKey(b => b.TownId);

            builder.Entity<Country>()
                .HasMany(c => c.Towns)
                .WithOne(t => t.Country)
                .HasForeignKey(t => t.CountryId);

            builder.Entity<User>()
                .HasMany(c => c.Orders)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);

            base.OnModelCreating(builder);
        }
    }
}

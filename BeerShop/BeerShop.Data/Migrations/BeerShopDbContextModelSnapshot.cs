﻿// <auto-generated />
namespace BeerShop.Data.Migrations
{
    using BeerShop.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;
    using System;

    [DbContext(typeof(BeerShopDbContext))]
    partial class BeerShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeerShop.Models.AccessoryOrder", b =>
                {
                    b.Property<int>("AccessoryId");

                    b.Property<int>("OrderId");

                    b.Property<int>("Quantity");

                    b.HasKey("AccessoryId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("AccessoryOrders");
                });

            modelBuilder.Entity("BeerShop.Models.BeerOrder", b =>
                {
                    b.Property<int>("BeerId");

                    b.Property<int>("OrderId");

                    b.Property<int>("Quantity");

                    b.HasKey("BeerId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("BeerOrders");
                });

            modelBuilder.Entity("BeerShop.Models.Brewery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Breweries");
                });

            modelBuilder.Entity("BeerShop.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Continent");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("BeerShop.Models.GiftSetOrder", b =>
                {
                    b.Property<int>("GiftSetId");

                    b.Property<int>("OrderId");

                    b.Property<int>("Quantity");

                    b.HasKey("GiftSetId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("GiftSetOrders");
                });

            modelBuilder.Entity("BeerShop.Models.GlassOrder", b =>
                {
                    b.Property<int>("GlassId");

                    b.Property<int>("OrderId");

                    b.Property<int>("Quantity");

                    b.HasKey("GlassId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("GlassOrders");
                });

            modelBuilder.Entity("BeerShop.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("LogType");

                    b.Property<string>("Table");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("BeerShop.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(3000);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsRead");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime>("SentOn");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("BeerShop.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<double>("Discount");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BeerShop.Models.Products.Accessory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(6000);

                    b.Property<string>("Image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.ToTable("Accessories");
                });

            modelBuilder.Entity("BeerShop.Models.Products.Beer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Alcohol");

                    b.Property<int>("Bitterness");

                    b.Property<int>("BreweryId");

                    b.Property<int>("Color");

                    b.Property<int>("Density");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(6000);

                    b.Property<int>("Gasification");

                    b.Property<string>("Image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.Property<string>("ServingTemp")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("StyleId");

                    b.Property<int>("Sweetness");

                    b.Property<int>("Volume");

                    b.HasKey("Id");

                    b.HasIndex("BreweryId");

                    b.HasIndex("StyleId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("BeerShop.Models.Products.GiftSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(6000);

                    b.Property<string>("Image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.ToTable("GiftSets");
                });

            modelBuilder.Entity("BeerShop.Models.Products.Glass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(6000);

                    b.Property<string>("Image");

                    b.Property<int>("Material");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int>("Volume");

                    b.HasKey("Id");

                    b.ToTable("Glasses");
                });

            modelBuilder.Entity("BeerShop.Models.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("BeerShop.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastLogin");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<DateTime>("RegisteredOn");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BeerShop.Models.AccessoryOrder", b =>
                {
                    b.HasOne("BeerShop.Models.Products.Accessory", "Accessory")
                        .WithMany("Orders")
                        .HasForeignKey("AccessoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeerShop.Models.Order", "Order")
                        .WithMany("Accessories")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeerShop.Models.BeerOrder", b =>
                {
                    b.HasOne("BeerShop.Models.Products.Beer", "Beer")
                        .WithMany("Orders")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeerShop.Models.Order", "Order")
                        .WithMany("Beers")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BeerShop.Models.Brewery", b =>
                {
                    b.HasOne("BeerShop.Models.Country", "Country")
                        .WithMany("Breweries")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeerShop.Models.GiftSetOrder", b =>
                {
                    b.HasOne("BeerShop.Models.Products.GiftSet", "GiftSet")
                        .WithMany("Orders")
                        .HasForeignKey("GiftSetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeerShop.Models.Order", "Order")
                        .WithMany("GiftSets")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeerShop.Models.GlassOrder", b =>
                {
                    b.HasOne("BeerShop.Models.Products.Glass", "Glass")
                        .WithMany("Orders")
                        .HasForeignKey("GlassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeerShop.Models.Order", "Order")
                        .WithMany("Glasses")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeerShop.Models.Order", b =>
                {
                    b.HasOne("BeerShop.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BeerShop.Models.Products.Beer", b =>
                {
                    b.HasOne("BeerShop.Models.Brewery", "Brewery")
                        .WithMany("Beers")
                        .HasForeignKey("BreweryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeerShop.Models.Style", "Style")
                        .WithMany("Beers")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BeerShop.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BeerShop.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeerShop.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BeerShop.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

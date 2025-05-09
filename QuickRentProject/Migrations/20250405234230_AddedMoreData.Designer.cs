﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickRentProjectDb.Data;

#nullable disable

namespace QuickRentProject.Migrations
{
    [DbContext(typeof(QuickRentProjectDbContext))]
    [Migration("20250405234230_AddedMoreData")]
    partial class AddedMoreData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("QuickRentProject.Areas.Identity.Data.QuickRentProjectUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "be32842c-181f-40e0-abfe-fe9f9d64e0ae",
                            Email = "pheobe@example.com",
                            EmailConfirmed = true,
                            FirstName = "Pheobe",
                            LastName = "Townsend",
                            LockoutEnabled = false,
                            NormalizedEmail = "PHEOBE@EXAMPLE.COM",
                            NormalizedUserName = "PHOEBE@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEPk2yefXazfNKMAYqWrcMvgGWfNckv4OmCebUIO1Ds6hq3lp/ohWXLp/gr0xQmDYpA==",
                            PhoneNumber = "531531413",
                            PhoneNumberConfirmed = false,
                            Role = "Renter",
                            SecurityStamp = "9f826bd8-9118-4eaf-b849-499999ab63c5",
                            TwoFactorEnabled = false,
                            UserName = "Phoebe@example.com"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0269ed02-33d0-44b3-a023-1cb9d9505efc",
                            Email = "Rivka@example.com",
                            EmailConfirmed = true,
                            FirstName = "Rivka",
                            LastName = "Simmons",
                            LockoutEnabled = false,
                            NormalizedEmail = "RIVKA@EXAMPLE.COM",
                            NormalizedUserName = "RIVKA@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEH0SjaK2omO6nBtDUMkJ6LvB/oiMIuq57lzbha9Pu60536JPyuYofatS5zs1oi5D2A==",
                            PhoneNumber = "4211614135",
                            PhoneNumberConfirmed = false,
                            Role = "Owner",
                            SecurityStamp = "214c5880-8c07-4ddd-9fef-8390c7a2c35d",
                            TwoFactorEnabled = false,
                            UserName = "Rivka@example.com"
                        },
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d7db2983-fdf9-42ba-8f13-aa9d1424913e",
                            Email = "Alianna@example.com",
                            EmailConfirmed = true,
                            FirstName = "Alianna",
                            LastName = "Murray",
                            LockoutEnabled = false,
                            NormalizedEmail = "ALIANNA@EXAMPLE.COM",
                            NormalizedUserName = "ALIANNA@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEN5r/fTThlP79dnrClks72SgKmJHwqSH05cAjejql6DosrUqwN53QpefGI4NvGPAWw==",
                            PhoneNumber = "7415135315",
                            PhoneNumberConfirmed = false,
                            Role = "Renter",
                            SecurityStamp = "04837a95-108d-4c7d-82cc-d41a8a996da9",
                            TwoFactorEnabled = false,
                            UserName = "Alianna@example.com"
                        },
                        new
                        {
                            Id = "4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "de1452cf-04ab-4077-b3d2-4e1c52892a58",
                            Email = "Carolyn@example.com",
                            EmailConfirmed = true,
                            FirstName = "Carolyn",
                            LastName = "Reese",
                            LockoutEnabled = false,
                            NormalizedEmail = "CAROLYN@EXAMPLE.COM",
                            NormalizedUserName = "CAROLYN@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEOKGuQKJrgb0GLSf8LRL6nFX9krYjE53RSx+xVFgvT36eiaXtniC7uSDgO3pot0hHQ==",
                            PhoneNumber = "631641431",
                            PhoneNumberConfirmed = false,
                            Role = "Renter",
                            SecurityStamp = "78f6550a-b11a-4fc0-803c-8f81180a30b2",
                            TwoFactorEnabled = false,
                            UserName = "Carolyn@example.com"
                        },
                        new
                        {
                            Id = "5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d9c160bd-02c4-4cff-8a64-4705557aa44e",
                            Email = "Damian@example.com",
                            EmailConfirmed = true,
                            FirstName = "Damian",
                            LastName = "Fletcher",
                            LockoutEnabled = false,
                            NormalizedEmail = "DAMIAN@EXAMPLE.COM",
                            NormalizedUserName = "DAMIAN@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAENJaJQNX3l+RCgxAKgJv1HSEZeHFTB4zex9+db+BWi1z3nwtXYXkhCqIyODp8dkuYQ==",
                            PhoneNumber = "5551234567",
                            PhoneNumberConfirmed = false,
                            Role = "Owner",
                            SecurityStamp = "96f0942d-0b43-4efd-9b83-59ff9c6ba9fa",
                            TwoFactorEnabled = false,
                            UserName = "Damian@example.com"
                        },
                        new
                        {
                            Id = "6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b1c4971d-ccba-4f5d-a74b-66c0d55dacd4",
                            Email = "Elara@example.com",
                            EmailConfirmed = true,
                            FirstName = "Elara",
                            LastName = "Whitmore",
                            LockoutEnabled = false,
                            NormalizedEmail = "ELARA@EXAMPLE.COM",
                            NormalizedUserName = "ELARA@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEPczRG4U3NPIUQm4xT+ZZKE8xCV7YVoCrd92SZp2krtZ1x9+W94gVnnkxZKzf1rx6Q==",
                            PhoneNumber = "5552345678",
                            PhoneNumberConfirmed = false,
                            Role = "Renter",
                            SecurityStamp = "db6a3937-78bc-4392-882a-5e6c6008756b",
                            TwoFactorEnabled = false,
                            UserName = "Elara@example.com"
                        },
                        new
                        {
                            Id = "7",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "758cc3a5-d4db-459d-bef5-d1ec7b7f9828",
                            Email = "Gregory@example.com",
                            EmailConfirmed = true,
                            FirstName = "Gregory",
                            LastName = "Holloway",
                            LockoutEnabled = false,
                            NormalizedEmail = "GREGORY@EXAMPLE.COM",
                            NormalizedUserName = "GREGORY@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEO5lhlf29kEZVJ+9Hf9VgRQsulwnSQ4jGfTatW1k/x1eVeozLweXaU+FndQ4LhfhJA==",
                            PhoneNumber = "5553456789",
                            PhoneNumberConfirmed = false,
                            Role = "Renter",
                            SecurityStamp = "aae9cb5e-d988-411b-970b-43ded561542c",
                            TwoFactorEnabled = false,
                            UserName = "Gregory@example.com"
                        },
                        new
                        {
                            Id = "8",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f524cc1d-7b8e-44b2-8efd-d912e6f961d1",
                            Email = "Hazel@example.com",
                            EmailConfirmed = true,
                            FirstName = "Hazel",
                            LastName = "Bridges",
                            LockoutEnabled = false,
                            NormalizedEmail = "HAZEL@EXAMPLE.COM",
                            NormalizedUserName = "HAZEL@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEIJL5Up59ieP5n954/dV3ScP28CBGnSkU789gKAo0JxIquO0oMMsTvGmFWM6VvMr8w==",
                            PhoneNumber = "5554567890",
                            PhoneNumberConfirmed = false,
                            Role = "Owner",
                            SecurityStamp = "d2e36fc1-99eb-44c3-999f-6d41513fb52f",
                            TwoFactorEnabled = false,
                            UserName = "Hazel@example.com"
                        },
                        new
                        {
                            Id = "9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9ba256f0-f2a6-4cb2-8a20-725bef507e10",
                            Email = "Ivan@example.com",
                            EmailConfirmed = true,
                            FirstName = "Ivan",
                            LastName = "Langley",
                            LockoutEnabled = false,
                            NormalizedEmail = "IVAN@EXAMPLE.COM",
                            NormalizedUserName = "IVAN@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEErJGjyLylptcVoNhmzD32isu8vzBgPHfl4W4kn3GqIKUvvdqgxjlT2xbFPZV3tH8w==",
                            PhoneNumber = "5555678901",
                            PhoneNumberConfirmed = false,
                            Role = "Renter",
                            SecurityStamp = "1855e896-8998-47f7-a78f-f93cdbe0ed5a",
                            TwoFactorEnabled = false,
                            UserName = "Ivan@example.com"
                        },
                        new
                        {
                            Id = "10",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "96d31260-e442-4e44-a943-6416ae2b8145",
                            Email = "Jasmine@example.com",
                            EmailConfirmed = true,
                            FirstName = "Jasmine",
                            LastName = "Everly",
                            LockoutEnabled = false,
                            NormalizedEmail = "JASMINE@EXAMPLE.COM",
                            NormalizedUserName = "JASMINE@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEEtWkwy7zg29W90xi96tiq9lOPtPs8EVF9auosiwMBa7ShJKT5y+LvrW2+riqCxCiQ==",
                            PhoneNumber = "5556789012",
                            PhoneNumberConfirmed = false,
                            Role = "Owner",
                            SecurityStamp = "b6607cab-8696-47cb-947b-ec8624b12806",
                            TwoFactorEnabled = false,
                            UserName = "Jasmine@example.com"
                        });
                });

            modelBuilder.Entity("QuickRentProject.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("RenterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("BookingId");

                    b.HasIndex("ItemId");

                    b.HasIndex("RenterId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("QuickRentProject.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("ItemId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("QuickRentProject.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PaymentId");

                    b.HasIndex("BookingId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("QuickRentProject.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ReviewId");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("QuickRentProject.Areas.Identity.Data.QuickRentProjectUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("QuickRentProject.Areas.Identity.Data.QuickRentProjectUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuickRentProject.Areas.Identity.Data.QuickRentProjectUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("QuickRentProject.Areas.Identity.Data.QuickRentProjectUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuickRentProject.Models.Booking", b =>
                {
                    b.HasOne("QuickRentProject.Models.Item", "Item")
                        .WithMany("Bookings")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuickRentProject.Areas.Identity.Data.QuickRentProjectUser", "Renter")
                        .WithMany("Bookings")
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Renter");
                });

            modelBuilder.Entity("QuickRentProject.Models.Item", b =>
                {
                    b.HasOne("QuickRentProject.Areas.Identity.Data.QuickRentProjectUser", "Owner")
                        .WithMany("Items")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("QuickRentProject.Models.Payment", b =>
                {
                    b.HasOne("QuickRentProject.Models.Booking", "Booking")
                        .WithMany("Payments")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("QuickRentProject.Models.Review", b =>
                {
                    b.HasOne("QuickRentProject.Models.Item", "Item")
                        .WithMany("Reviews")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuickRentProject.Areas.Identity.Data.QuickRentProjectUser", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuickRentProject.Areas.Identity.Data.QuickRentProjectUser", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Items");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("QuickRentProject.Models.Booking", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("QuickRentProject.Models.Item", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}

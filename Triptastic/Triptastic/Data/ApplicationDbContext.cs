using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Triptastic.Enums;
using Triptastic.Models;

namespace Triptastic.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

        public DbSet<PropertyAmenity> PropertyAmenities { get; set; }

        public DbSet<PropertyImage> PropertyImages { get; set; }

        public DbSet<RoomImage> RoomImages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PropertyAmenity>()
                .HasKey(pa => new { pa.PropertyId, pa.AmenityId });

            builder.Entity<PropertyAmenity>()
                .HasOne(pa => pa.Property)
                .WithMany(p => p.PropertyAmenities)
                .HasForeignKey(pa => pa.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PropertyAmenity>()
                .HasOne(pa => pa.Amenity)
                .WithMany(a => a.PropertyAmenities)
                .HasForeignKey(pa => pa.AmenityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RoomType>()
                .Property(rt => rt.BasePricePerNight)
                .HasColumnType("decimal(18, 2)");

            builder.Entity<Booking>()
                .Property(b => b.TotalPrice)
                .HasColumnType("decimal(18, 2)");

            builder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18, 2)");

            builder.Entity<Property>()
                .Property(p => p.Type)
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.Entity<Booking>()
                .Property(b => b.Status)
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.Entity<Booking>()
                .HasOne(b => b.Review)
                .WithOne(r => r.Booking)
                .HasForeignKey<Review>(r => r.BookingId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<RoomType>()
                .HasMany(rt => rt.Bookings)
                .WithOne(b => b.RoomType)
                .HasForeignKey(b => b.RoomTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Property>()
                .HasMany(p => p.RoomTypes)
                .WithOne(rt => rt.Property)
                .HasForeignKey(rt => rt.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Property>()
               .HasMany(p => p.Images)
               .WithOne(pi => pi.Property)
               .HasForeignKey(pi => pi.PropertyId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<RoomType>()
               .HasMany(rt => rt.Images)
               .WithOne(ri => ri.RoomType)
               .HasForeignKey(ri => ri.RoomTypeId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

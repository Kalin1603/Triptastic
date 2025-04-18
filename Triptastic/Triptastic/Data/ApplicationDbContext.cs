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
    }
}

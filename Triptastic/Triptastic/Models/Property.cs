using System.ComponentModel.DataAnnotations;
using Triptastic.Enums;

namespace Triptastic.Models
{
    public class Property
    {
        [Key] // Първичен ключ
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; } = null!;

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(100)]
        public string? Country { get; set; }

        public PropertyType Type { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public DateTime AddedDate { get; set; } = DateTime.UtcNow;

        public virtual ICollection<RoomType> RoomTypes { get; set; } = new HashSet<RoomType>();

        public virtual ICollection<PropertyAmenity> PropertyAmenities { get; set; } = new HashSet<PropertyAmenity>();

        public virtual ICollection<PropertyImage> Images { get; set; } = new HashSet<PropertyImage>();

        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    }
}

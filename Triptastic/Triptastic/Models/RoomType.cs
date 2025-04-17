using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Triptastic.Models
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; } 

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public int Capacity { get; set; } 

        [Required]
        [Column(TypeName = "decimal(18, 2)")] 
        public decimal BasePricePerNight { get; set; }

        [Required]
        public int TotalQuantity { get; set; } 

        [ForeignKey(nameof(PropertyId))]
        public virtual Property Property { get; set; } = null!;

        public virtual ICollection<RoomImage> Images { get; set; } = new HashSet<RoomImage>();

        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
    }
}

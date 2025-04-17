using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Triptastic.Enums;

namespace Triptastic.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(RoomType))]
        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; } 

        [Required]
        public DateTime EndDate { get; set; }   

        [Required]
        public int NumberOfGuests { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.UtcNow; 

        public BookingStatus Status { get; set; } = BookingStatus.PendingPayment;

        public string? PaymentIntentId { get; set; }

        public virtual ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();

        public virtual Review? Review { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Triptastic.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Booking))]
        public int BookingId { get; set; }
        public virtual Booking Booking { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(50)]
        public string PaymentGateway { get; set; } = null!; 

        [MaxLength(255)] 
        public string? TransactionId { get; set; } 

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = null!; 

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

    }
}

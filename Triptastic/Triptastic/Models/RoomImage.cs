using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Triptastic.Models
{
    public class RoomImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(RoomType))]
        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string ImageUrl { get; set; } = null!;

        public bool IsPrimary { get; set; } = false;

    }
}

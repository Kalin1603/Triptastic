using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Triptastic.Models
{
    public class PropertyImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; } = null!;

        [Required]
        [MaxLength(500)] 
        public string ImageUrl { get; set; } = null!;

        public bool IsPrimary { get; set; } = false;

    }
}

using System.ComponentModel.DataAnnotations;

namespace Triptastic.Models
{
    public class Amenity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(50)]
        public string? Icon { get; set; }

        public virtual ICollection<PropertyAmenity> PropertyAmenities { get; set; } = new HashSet<PropertyAmenity>();

    }
}

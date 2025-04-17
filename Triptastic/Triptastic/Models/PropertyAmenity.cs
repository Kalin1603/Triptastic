using System.ComponentModel.DataAnnotations.Schema;

namespace Triptastic.Models
{
    public class PropertyAmenity
    {
        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; } = null!;


        [ForeignKey(nameof(Amenity))]
        public int AmenityId { get; set; }
        public virtual Amenity Amenity { get; set; } = null!;

    }
}

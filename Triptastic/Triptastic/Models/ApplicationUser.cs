using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Triptastic.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } 

        [PersonalData]
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } 

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true; 

        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

    }
}

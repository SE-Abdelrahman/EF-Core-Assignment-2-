using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_2.Models
{
    [Table("EventOrganizers")] 
    internal class Organizer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string? CompanyName { get; set; } 

        public bool IsVerified { get; set; }

        public OrganizerProfile Profile { get; set; }

        public ICollection<Event> Events { get; set; } = new HashSet<Event>();
    }
}

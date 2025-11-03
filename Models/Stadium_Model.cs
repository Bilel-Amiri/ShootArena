using System.ComponentModel.DataAnnotations;
using Shoot.Models;

namespace Shoot.Models
{
    public class Stadium_Model
    {
        [Key]
        public int Stadium_id { get; set; }
        public string Name { get; set; } = "";
        public string Location { get; set; } = "";
       
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; } = true;

        // Navigation property
        public ICollection<Reservation_Model>? Reservations { get; set; }

    }
}

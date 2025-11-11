using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
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

       
        [Required, EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";


        [JsonIgnore]
        public ICollection<Reservation_Model>? Reservations { get; set; }

    }
}

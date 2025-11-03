using System.ComponentModel.DataAnnotations;
using Shoot.Models;

namespace Shoot.Models
{
    public class Client_Model
    {
        [Key]
        public int Client_id { get; set; }

        [Required]
        public string FullName { get; set; } = "";

        [Required, EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string PasswordHash { get; set; } = ""; 

        public string Phone { get; set; } = "";

        public ICollection<Reservation_Model>? Reservations { get; set; }


    }
}

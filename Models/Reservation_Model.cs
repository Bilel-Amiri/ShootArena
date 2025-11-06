using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoot.Models
{
    public class Reservation_Model
    {
        [Key]
        public int Reservation_id { get; set; }

        [Required]
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client_Model? Client { get; set; }

        [Required]
        public int StadiumId { get; set; }

        [ForeignKey("StadiumId")]
        public Stadium_Model? Stadium { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        // Default match duration: 1 hour 30 minutes
        public TimeSpan Duration { get; set; } = TimeSpan.FromMinutes(90);

        // Status: Pending, Confirmed, or Cancelled
        [Required]
        public string Status { get; set; } = "Pending";
    }
}

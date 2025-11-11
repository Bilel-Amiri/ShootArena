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
        [DataType(DataType.Date)]
        public DateOnly ReservationDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeOnly StartTime { get; set; }

      
        public TimeSpan Duration { get; set; } = TimeSpan.FromMinutes(90);

       
        [Required]
        public string Status { get; set; } = "Pending";
    }
}

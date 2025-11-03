using System.ComponentModel.DataAnnotations;
using Shoot.Controllers;

namespace Shoot.Models
{
    public class Reservation_Model
    {

        [Key]
        public int Reservation_id { get; set; }

        public int ClientId { get; set; }
        public Client_Model? Client { get; set; }

        public int StadiumId { get; set; }
        public Stadium_Model? Stadium { get; set; }

        public DateTime ReservationDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

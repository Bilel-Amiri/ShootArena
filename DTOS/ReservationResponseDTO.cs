namespace Shoot.DTOS
{
    public class ReservationResponseDTO
    {
        public int Reservation_id { get; set; }
        public string ClientName { get; set; } = "";
        public string StadiumName { get; set; } = "";
        public DateTime ReservationDate { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string Status { get; set; } = "";


    }
}

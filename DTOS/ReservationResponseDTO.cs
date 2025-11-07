namespace Shoot.DTOS
{
    public class ReservationResponseDTO
    {
        public int Reservation_id { get; set; }
        public string ClientName { get; set; } = "";
        public string StadiumName { get; set; } = "";
        public DateOnly ReservationDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string Status { get; set; } = "";


    }
}

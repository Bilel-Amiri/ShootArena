namespace Shoot.DTOS
{
    public class ReservationCreateDTO
    {

        public int ClientId { get; set; }
        public int StadiumId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime StartTime { get; set; }
    }
}

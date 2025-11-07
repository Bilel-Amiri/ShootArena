namespace Shoot.DTOS
{
    public class ReservationCreateDTO
    {

        public int ClientId { get; set; }
        public int StadiumId { get; set; }
        public DateOnly ReservationDate { get; set; }
        public TimeOnly StartTime { get; set; }
    }
}

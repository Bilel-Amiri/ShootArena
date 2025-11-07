using Microsoft.EntityFrameworkCore;
using Shoot.DBContext;
using Shoot.DTOS;
using Shoot.Models;

namespace Shoot.Service
{
    public class Reservation_Service
    {


        private readonly ShootDBContext _context;

        public Reservation_Service(ShootDBContext context)
        {
            _context = context;
        }

        public async Task<ReservationResponseDTO>  CreateReservation(ReservationCreateDTO dto)
        {


            var stadium = await _context.Stadiums.FindAsync(dto.StadiumId);

            if (stadium == null)
            {
                throw new Exception("Stadium not found");
            }





            bool conflict = await _context.Reservations.AnyAsync(r =>
                r.StadiumId == dto.StadiumId &&
                r.ReservationDate == dto.ReservationDate &&
                r.StartTime == dto.StartTime);

            if (conflict)
            {
                throw new Exception("This time slot is already booked.");
            }


            var reservation = new Reservation_Model
            {

                ClientId = dto.ClientId,
                StadiumId = dto.StadiumId,
                ReservationDate=dto.ReservationDate,
                StartTime=dto.StartTime,  
                Status = "en attente"

            };
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();


            return new ReservationResponseDTO
            {
                Reservation_id = reservation.Reservation_id,
                ClientName = (await _context.Clients.FindAsync(dto.ClientId))?.FullName ?? "Unknown",
                StadiumName = stadium.Name,
                ReservationDate = reservation.ReservationDate,
                StartTime = reservation.StartTime,
                Duration = reservation.Duration,
                Status = reservation.Status
            };


        }




        public async Task<string> ConfirmReservationAsync(int reservationId , int Stadium_id)
        {

            var reservation = await _context.Reservations
         .Include(r => r.Stadium)
         .FirstOrDefaultAsync(r =>
             r.Reservation_id == reservationId &&
             r.Status == "En attente" &&
             r.Stadium.Stadium_id == Stadium_id);




            if (reservation == null)
                throw new Exception("Reservation not found or not pending.");



            reservation.Status = "confirmèe";
            await _context.SaveChangesAsync();


            return "Reservation confirmed successfully.";

        }


        public async Task<string> RejectReservationAsync(int reservationId , int Stadium_id)
        {

            var reservation = await _context.Reservations
        .Include(r => r.Stadium)
        .FirstOrDefaultAsync(r =>
            r.Reservation_id == reservationId &&
            r.Status == "En attente" &&
            r.Stadium.Stadium_id == Stadium_id);




            if (reservation == null)
            
                throw new Exception("Reservation not found or not pending.");
            



            reservation.Status = "refusèe";

            await _context.SaveChangesAsync();
            return "Reservation rejected successfully.";

        }






    }
}

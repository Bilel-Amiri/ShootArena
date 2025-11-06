using Microsoft.AspNetCore.Mvc;
using Shoot.DTOS;
using Shoot.Service;
using Microsoft.AspNetCore.Authorization;

namespace Shoot.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class ReservationController : Controller
    {


        private readonly Reservation_Service _reservationService;

        public ReservationController(Reservation_Service service)
        {
            _reservationService = service;
        }






        [Authorize(Roles = "Client")]
        [HttpPost("Create_Reservation")]

        public async Task<IActionResult> CreateReservation([FromBody] ReservationCreateDTO dto)
        {


            try
            {

               var clientIdClaim = User.FindFirst("id");


                if (clientIdClaim == null)
                    return Unauthorized(new { message = "Invalid token: missing Client ID claim." });

                dto.ClientId = int.Parse(clientIdClaim.Value);
                 

                var result = await _reservationService.CreateReservation(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }



    }
}

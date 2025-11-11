using Microsoft.AspNetCore.Mvc;
using Shoot.DTOS;
using Shoot.Service;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
                var clientIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

                dto.ClientId = int.Parse(clientIdClaim.Value);


                if (clientIdClaim == null)
                    return Unauthorized(new { message = "Invalid token: missing Client ID claim." });


                var result = await _reservationService.CreateReservation(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }




        [Authorize(Roles = "Stadium")]

        [HttpPut("confirm/{reservationId}")]

        public async Task<IActionResult> ConfirmReservation(int reservationId)
        {

            try
            {

                var stadiumIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

                if (stadiumIdClaim == null)
                    return Unauthorized(new { message = "Invalid token: missing Owner ID claim." });


               int Stadiumid = int.Parse(stadiumIdClaim.Value);



                var result = await _reservationService.ConfirmReservationAsync(reservationId, Stadiumid);
                return Ok(new { message = result });



            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });

            }


        }





        [Authorize(Roles = "Stadium")]

        [HttpPut("reject/{reservationId}")]

        public async Task<IActionResult> RejectReservation(int reservationId )
        {

            try
            {

                var stadiumIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

                if (stadiumIdClaim == null)
                    return Unauthorized(new { message = "Invalid token: missing Owner ID claim." });


               int  Stadiumid = int.Parse(stadiumIdClaim.Value);



                var result = await _reservationService.RejectReservationAsync(reservationId, Stadiumid);
                return Ok(new { message = result });



            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });

            }





        }


       


      






    }
}

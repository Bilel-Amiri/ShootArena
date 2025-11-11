using Microsoft.AspNetCore.Mvc;
using Shoot.DBContext;
using Shoot.Models;
using Microsoft.AspNetCore.Identity;
using Shoot.Service;
using Shoot.DTOS;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Shoot.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : Controller
    {

        private readonly Stadium_Service _Stadiumservice;


        public StadiumController(Stadium_Service service)
        {
            _Stadiumservice = service;
        }




        [HttpPost("Registre_Stadium")]

        public async Task<IActionResult> RegistreStadAsync(Registre_StadiumDTO dTO)
        {

            var result = await _Stadiumservice.RegistreStadAsync(dTO);


            if (result == "Email already exists ")
            {

                return BadRequest(new { message = result });
            }

            return Ok(new { message = result });


        }


        [HttpPost("Login_Stadium")]

        public async Task<IActionResult> LoginStadAsync([FromBody] Login_Stadium dto)
        {

            var token = await _Stadiumservice.LoginStadAsync(dto.Email, dto.Password);

            if (token == null)
                return Unauthorized("Invalid email or password");

            return Ok(new { Token = token });

        }


        [Authorize(Roles = "Stadium")]
        [HttpGet("pending_reservations/{Stadiumid}")]

        public async Task<IActionResult> GetPandingReservations() {


            try
            {
                var stadiumIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

                if (stadiumIdClaim == null)
                    return Unauthorized(new { message = "Invalid token: missing Owner ID claim." });

                int Stadiumid = int.Parse(stadiumIdClaim.Value);




                var result = await _Stadiumservice.GetPandingReservationsAsync(Stadiumid);

                return Ok(result);

            }

            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }





        [Authorize(Roles = "Stadium")]
        [HttpGet("confirmed_reservations")]

        public async  Task<IActionResult> GetConfirmedReservations()
        {

            try
            {
                var stadiumIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

                if (stadiumIdClaim == null)
                    return Unauthorized(new { message = "Invalid token: missing Owner ID claim." });

                int Stadiumid = int.Parse(stadiumIdClaim.Value);




                var result = await _Stadiumservice.GetConfirmedReservationsAsync(Stadiumid);

                return Ok(result);

            }

            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }


        }







    }




    }


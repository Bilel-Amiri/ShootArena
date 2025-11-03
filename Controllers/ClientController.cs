using Microsoft.AspNetCore.Mvc;
using Shoot.DBContext;
using Shoot.Models;
using Microsoft.AspNetCore.Identity;
using Shoot.Service;
using Shoot.DTOS;


namespace Shoot.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly Client_Service _clientService;



        public ClientController(Client_Service clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("Registre")]

        public async Task<IActionResult> RegistreAsync (Registre_dto dto)
        {


            var result = await _clientService.RegistreAsync(dto);

            if (result == "Email already exists ") {
            
                return BadRequest(new { message = result });
            }

            return Ok(new { message = result });


        }




    
}
}

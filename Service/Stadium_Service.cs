using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shoot.DBContext;
using Shoot.DTOS;
using Shoot.Models;
using Shoot.Service;

namespace Shoot.Service
{
    public class Stadium_Service
    {

        private readonly ShootDBContext _context;
        private readonly PasswordHasher<Stadium_Model> _passwordHasher;
        private readonly JWTService _jwtService;


        public Stadium_Service(ShootDBContext context, PasswordHasher<Stadium_Model> passwordHasher, JWTService jwtService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;

        }

        public async Task<string> RegistreStadAsync(Registre_StadiumDTO dTO)
        {
            if (await _context.Stadiums.AnyAsync(c => c.Email == dTO.Email))
                return "Email already exists";

            var stadium = new Stadium_Model
            {
                Name = dTO.Name,
                Email = dTO.Email,
                Location = dTO.Location,
                Price = dTO.Price,

            };

            stadium.Password = _passwordHasher.HashPassword(stadium, dTO.Password);


            _context.Stadiums.Add(stadium);

            await _context.SaveChangesAsync();

            return "Account created successfully";




        }




        public async Task<string> LoginStadAsync(string email, string password)
        {


            var stadium = await _context.Stadiums.FirstOrDefaultAsync(s => s.Email == email);

            if (stadium == null)
                return null;


            var result = _passwordHasher.VerifyHashedPassword(stadium, stadium.Password, password);
            if (result == PasswordVerificationResult.Failed)
                return null;

            var token = _jwtService.GenerateToken(stadium.Stadium_id.ToString(), stadium.Email, "Stadium");
            return token;



        }


    }
}

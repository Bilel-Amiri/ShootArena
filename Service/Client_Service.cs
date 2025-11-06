using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shoot.DBContext;
using Shoot.DTOS;
using Shoot.Models;
using Shoot.Service;

namespace Shoot.Service
{
    public class Client_Service
    {

        private readonly ShootDBContext _context;
        private readonly PasswordHasher<Client_Model> _passwordHasher;
        private readonly JWTService _jwtService;

        public Client_Service(ShootDBContext context, JWTService jwtService)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<Client_Model>();
            _jwtService = jwtService;
        }


        public async Task<string>  RegistreAsync (Registre_dto dto)
        {
            if (await _context.Clients.AnyAsync(c => c.Email == dto.Email))
                return "Email already exists";

            var client = new Client_Model
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.PhoneNumber
            };


            client.PasswordHash = _passwordHasher.HashPassword(client, dto.Password);


            _context.Clients.Add(client);

            await _context.SaveChangesAsync();

            return "Account created successfully";




        }




        public async Task<string?> LoginAsync(string email, string password)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Email == email);

            if (client == null)
                return null;

            var result = _passwordHasher.VerifyHashedPassword(client, client.PasswordHash, password);
            if (result == PasswordVerificationResult.Failed)
                return null;

           
            var token = _jwtService.GenerateToken(client.Client_id.ToString(), client.Email, "Client");
            return token;
        }




    }
}

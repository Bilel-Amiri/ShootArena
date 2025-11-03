using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shoot.DBContext;
using Shoot.DTOS;
using Shoot.Models;

namespace Shoot.Service
{
    public class Client_Service
    {

        private readonly ShootDBContext _context;
        private readonly PasswordHasher<Client_Model> _passwordHasher;

        public Client_Service(ShootDBContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<Client_Model>();
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




    }
}


using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;




namespace Shoot.Service
{
    public class JWTService
    {

        private readonly IConfiguration configuration;


        public JWTService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public string GenerateToken(string user_id , string Email , string Role)
        {

            var claims = new[]
        {
             new Claim(JwtRegisteredClaimNames.Sub, user_id),


            new Claim(JwtRegisteredClaimNames.Email, Email),
            new Claim(ClaimTypes.Role, Role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
           issuer: configuration["Jwt:Issuer"],
           audience: configuration["Jwt:Audience"],
           claims: claims,
           expires: DateTime.Now.AddHours(6),
           signingCredentials: creds
       );

            return new JwtSecurityTokenHandler().WriteToken(token);



        }



    }
}


using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Shoot.DBContext;
using Shoot.Models;
using Shoot.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace Shoot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           

            builder.Services.AddControllers();

           


             // connection string 
             //............................


            builder.Services.AddDbContext<ShootDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShootConnection")));


            //......................................

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();




            //My services 
            //................................
            builder.Services.AddSingleton<JWTService>();
            builder.Services.AddScoped<Client_Service>();
            builder.Services.AddScoped<Stadium_Service>();
            builder.Services.AddScoped<Reservation_Service>();


            builder.Services.AddScoped<Microsoft.AspNetCore.Identity.PasswordHasher<Shoot.Models.Stadium_Model>>();




            //.......................................






            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});



            builder.Services.AddAuthorization();



            var app = builder.Build();

           
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

           


            app.MapControllers();


            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();








            app.Run();


           
        }
    }
}

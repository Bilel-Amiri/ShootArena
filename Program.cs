
using Microsoft.EntityFrameworkCore;
using Shoot.DBContext;
using Shoot.Models;
using Shoot.Service;

namespace Shoot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           

            builder.Services.AddControllers();



            builder.Services.AddDbContext<ShootDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShootConnection")));


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddScoped<Client_Service>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

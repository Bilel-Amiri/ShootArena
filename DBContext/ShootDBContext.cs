using Microsoft.EntityFrameworkCore;

using System;
using Shoot.Models;

namespace Shoot.DBContext
{
    public class ShootDBContext : DbContext
    {



        public ShootDBContext(DbContextOptions<ShootDBContext> options) : base(options) { }



        public DbSet<Client_Model> Clients { get; set; }
        public DbSet<Stadium_Model> Stadiums { get; set; }
        public DbSet<Reservation_Model> Reservations { get; set; }
    }
}

using DreamHomeApp.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamHomeApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Apartament> Apartaments { get; set; }
        public DbSet<Basement> Basements { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ProductivityAPI.Model;
using System.Collections.Generic;

namespace ProductivityAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Weight> Weights { get; set; }
        public DbSet<BloodPressure> BloodPressures { get; set; }
        public DbSet<Medications> Medications { get; set; }
        public DbSet<Saturation> Saturations { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}

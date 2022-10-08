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
    }
}

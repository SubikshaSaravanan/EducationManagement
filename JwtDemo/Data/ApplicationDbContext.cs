using JwtDemo.Models.JwtPostgresDemo.Models;
using JwtPostgresDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtPostgresDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}

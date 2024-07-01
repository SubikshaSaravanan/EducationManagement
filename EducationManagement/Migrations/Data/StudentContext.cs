using EducationManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace EducationManagement.Data
{
    public class StudentContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public StudentContext(IConfiguration configuration, DbContextOptions<StudentContext> options) : base(options)
        {
            Configuration = configuration;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Classes> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Angitha", Age = 10, ClassId = 4 },
                new Student { Id = 2, Name = "Ashmitha", Age = 8, ClassId = 3 },
                new Student { Id = 3, Name = "Isai", Age = 15, ClassId = 11 },
                new Student { Id = 4, Name = "Madhu", Age = 12, ClassId = 9 },
                new Student { Id = 5, Name = "Kiruthika", Age = 12, ClassId = 9 },
                new Student { Id = 6, Name = "Kavya", Age = 15, ClassId = 11 },
                new Student { Id = 7, Name = "Dharshini", Age = 10, ClassId = 4 }
            );

            modelBuilder.Entity<Classes>()
            .HasKey(d => d.ClassId);

            modelBuilder.Entity<Classes>().HasData(
                new Classes { ClassId = 4, ClassName = "Science" },
                new Classes { ClassId = 3, ClassName = "Maths" },
                new Classes { ClassId = 11, ClassName = "Chemistry" },
                new Classes { ClassId = 9, ClassName = "Physics" }
            );

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassId);
        }
    }
}

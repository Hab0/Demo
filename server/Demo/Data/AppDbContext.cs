using Demo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "omar",
                    LastName = "lahbabi",
                    Email = "olahb@gmail.com",
                    PhoneNumber = "1234567890",
                    Position = "Software Engineer",
                    Department = "Engineering"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "ahmed",
                    LastName = "lahbabi",
                    Email = "alahb@gmail.com",
                    PhoneNumber = "0987654321",
                    Position = "Product Manager",
                    Department = "Product"
                }
            );
        }*/
    }
}

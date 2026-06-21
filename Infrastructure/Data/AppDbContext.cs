using System;
using System.Collections.Generic;
using System.Text;
using Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees {  get; set; }
        public DbSet<Department> Departments {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationship
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Department>().HasData(
                 new Department { Id = 1, Name = "Engineering" },
                new Department { Id = 2, Name = "HR" },
                 new Department { Id = 3, Name = "Finance" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Ahmed Ali", Salary = 12000, DepartmentId = 1 },
                new Employee { Id = 2, Name = "Sara Mohamed", Salary = 9500, DepartmentId = 2 },
                new Employee { Id = 3, Name = "Ahmed Hassan", Salary = 8000, DepartmentId = 1 },
                new Employee { Id = 4, Name = "Mona Khaled", Salary = 15000, DepartmentId = 3 },
                new Employee { Id = 5, Name = "Omar Tarek", Salary = 7000, DepartmentId = 2 },
                new Employee { Id = 6, Name = "Ahmed Samir", Salary = 11000, DepartmentId = 1 },
                new Employee { Id = 7, Name = "Laila Fathy", Salary = 9000, DepartmentId = 3 },
                new Employee { Id = 8, Name = "Youssef Adel", Salary = 13000, DepartmentId = 1 },
                new Employee { Id = 9, Name = "Nour Sami", Salary = 6500, DepartmentId = 2 },
                new Employee { Id = 10, Name = "Karim Magdy", Salary = 10500, DepartmentId = 3 },
                 new Employee { Id = 11, Name = "Kareem Ali", Salary = 12000, DepartmentId = 1 },
                new Employee { Id = 12, Name = "Sara Salama", Salary = 9500, DepartmentId = 2 },
                new Employee { Id = 13, Name = "Ahmed Yasser", Salary = 8000, DepartmentId = 1 },
                new Employee { Id = 14, Name = "Rawda Khaled", Salary = 15000, DepartmentId = 3 },
                new Employee { Id = 15, Name = "Omar Khalid", Salary = 7000, DepartmentId = 2 },
                new Employee { Id = 16, Name = "Mohamed Samir", Salary = 11000, DepartmentId = 1 },
                new Employee { Id = 17, Name = "Laila Zaher", Salary = 9000, DepartmentId = 3 },
                new Employee { Id = 18, Name = "Youssef Sobhi", Salary = 13000, DepartmentId = 1 },
                new Employee { Id = 19, Name = "Ziena Sami", Salary = 6500, DepartmentId = 2 },
                new Employee { Id = 20, Name = "Karim Wael", Salary = 10500, DepartmentId = 3 }
            );
        }
    }
}

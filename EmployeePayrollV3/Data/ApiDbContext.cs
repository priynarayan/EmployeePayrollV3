using EmployeePayrollV3.Models.DBModel;
using Microsoft.EntityFrameworkCore;

namespace EmployeePayrollV3.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<JobClass> JobClasses { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EmpDB2;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasKey(u => u.Id);

            modelBuilder.Entity<Role>()
                        .HasKey(u => u.Id);

            modelBuilder.Entity<JobClass>()
                        .HasKey(u => u.Id);

            modelBuilder.Entity<Salary>()
                        .HasKey(u => u.Id);

        }
    }
}

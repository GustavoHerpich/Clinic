using Clinic.Data.Map;
using Clinic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data
{
    public class Context(DbContextOptions<Context> options) : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

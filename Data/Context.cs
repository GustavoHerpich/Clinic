using Clinic.Data.Map;
using Clinic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new PatientMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

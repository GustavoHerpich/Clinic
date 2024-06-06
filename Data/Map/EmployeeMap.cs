using Clinic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Data.Map
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.UserName).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Password).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Role).IsRequired().HasConversion<string>();
        }
    }
}

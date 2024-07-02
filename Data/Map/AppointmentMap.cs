using Clinic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Data.Map
{
    public class AppointmentMap : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.IdDoctor).IsRequired();
            builder.Property(e => e.IdPatient).IsRequired();
            builder.Property(e => e.IdUser).IsRequired();
        }
    }
}

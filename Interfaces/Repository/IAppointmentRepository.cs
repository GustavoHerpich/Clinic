using Clinic.Entities;
using Clinic.Models.Appointment;

namespace Clinic.Interfaces.Repository
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        Task<IEnumerable<FindAppointmentModel>> FindAsync();
    }
}

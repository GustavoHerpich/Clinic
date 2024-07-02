using Clinic.Entities;
using Clinic.Models.Appointment;

namespace Clinic.Interfaces.Business
{
    public interface IAppointmentBusiness : IBaseBusiness<Appointment>
    {
        Task<IEnumerable<FindAppointmentModel>> FindAsync();
    }
}

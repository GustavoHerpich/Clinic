using Clinic.Entities;

namespace Clinic.Interfaces.Repository
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        Task<Doctor> FindByCrmAsync(string crm, int id = 0);
    }
}

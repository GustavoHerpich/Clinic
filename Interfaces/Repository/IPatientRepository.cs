using Clinic.Entities;

namespace Clinic.Interfaces.Repository
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Task<Patient> FindByCpfAsync(string cpf, int id = 0);
    }
}

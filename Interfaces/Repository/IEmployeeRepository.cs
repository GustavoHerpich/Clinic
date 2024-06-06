using Clinic.Entities;

namespace Clinic.Interfaces.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<Employee> FindOneAsync(string userName, string password);
    }
}

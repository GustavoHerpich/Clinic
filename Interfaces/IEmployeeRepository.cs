using Clinic.Models;

namespace Clinic.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<Employee> FindOneAsync(string userName, string password);
    }
}

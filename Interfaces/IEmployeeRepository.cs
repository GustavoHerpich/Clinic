using Clinic.Entities;

namespace Clinic.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<Employee> FindOneAsync(string userName);
    }
}

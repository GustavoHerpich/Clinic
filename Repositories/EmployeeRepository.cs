using Clinic.Data;
using Clinic.Interfaces;
using Clinic.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Employee>> FindAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> FindOneAsync(string userName, string password)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.UserName.Equals(userName) && x.Password.Equals(password));
        }
    }
}

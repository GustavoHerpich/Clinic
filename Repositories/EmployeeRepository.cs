using Clinic.Data;
using Clinic.Entities;
using Microsoft.EntityFrameworkCore;
using Clinic.Interfaces.Repository;

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
            try
            {
                return await _context.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<Employee> FindOneAsync(string userName, string password)
        {
            try
            {
                return await _context.Employees.FirstOrDefaultAsync(x => x.UserName.Equals(userName) && x.Password.Equals(password));
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            try
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();

                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            try
            {
                var existingEmployee = await _context.Employees.FindAsync(employee.Id) ?? throw new KeyNotFoundException();

                _context.Entry(existingEmployee).State = EntityState.Detached;
                _context.Entry(employee).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return employee;
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id) ?? throw new KeyNotFoundException();
            try
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<Employee> FindById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}

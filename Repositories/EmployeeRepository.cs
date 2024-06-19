using Clinic.Data;
using Clinic.Entities;
using Clinic.Exceptions;
using Microsoft.EntityFrameworkCore;
using Clinic.Interfaces.Repository;

namespace Clinic.Repositories
{
    public class EmployeeRepository(Context context) : IEmployeeRepository
    {
        private readonly Context _context = context;

        public async Task<List<Employee>> FindAllAsync()
            => await _context.Employees.ToListAsync();

        public async Task<Employee> FindOneAsync(string userName)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.UserName.Equals(userName));
            //if (employee == null)
            //    throw new NotFoundException("Funcionário não encontrado.");
            return employee;
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(employee.Id);
            if (existingEmployee == null)
                throw new NotFoundException("Funcionário não encontrado.");

            existingEmployee.UserName = employee.UserName;
            existingEmployee.Password = employee.Password;
            existingEmployee.Role = employee.Role;

            await _context.SaveChangesAsync();
            return existingEmployee;
        }

        public async Task DeleteAsync(int id)
        {
            var existingEmployee = await _context.Employees.FindAsync(id);
            if (existingEmployee == null)
                throw new NotFoundException("Funcionário não encontrado.");

            _context.Employees.Remove(existingEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> FindById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}

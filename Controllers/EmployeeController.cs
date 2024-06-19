using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Clinic.Interfaces.Repository;
using Clinic.Entities;
using Clinic.Models.Employee;
using Clinic.Exceptions;

namespace Clinic.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController(IEmployeeRepository employeeRepository) : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        [HttpGet("FindAll")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Employee>>> FindAllAsync()
        {
            var employees = await _employeeRepository.FindAllAsync();

            return Ok(employees);
        }

        [HttpGet("FindOne/{userName}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Employee>> FindOneAsync(string userName)
        {
            var employee = await _employeeRepository.FindOneAsync(userName);

            return Ok(employee);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Employee>> CreateAsync(EmployeeRequest employeeRequest)
        {
            var existingEmployee = await _employeeRepository.FindOneAsync(employeeRequest.UserName);
            if (existingEmployee != null)
                throw new BadRequestException("Funcionario já existe");

            var employee = new Employee
            {
                UserName = employeeRequest.UserName,
                Password = employeeRequest.Password,
                Role = employeeRequest.Role
            };
            employee = await _employeeRepository.CreateAsync(employee);
            return Ok(employee);
        }

        [HttpPut("Update/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, [FromBody] EmployeeRequest employeeRequest)
        {
            var employee = new Employee
            {
                Id = id,
                UserName = employeeRequest.UserName,
                Password = employeeRequest.Password,
                Role = employeeRequest.Role
            };

            var updatedEmployee = await _employeeRepository.UpdateAsync(employee);
            return Ok(updatedEmployee);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> FindById(int id)
        {
            var user = await _employeeRepository.FindById(id);

            if (user == null)
                return NotFound();
            
            return Ok();
        }
    }
}
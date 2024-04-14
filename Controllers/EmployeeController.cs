using Clinic.Interfaces;
using Clinic.Models;
using Clinic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] Employee login)
        {
            var employee = await _employeeRepository.FindOneAsync(login.UserName, login.Password);
            if (employee == null)
                throw new UnauthorizedAccessException();

            var token = TokenService.GenerateToken(employee);

            return new
            {
                login = login.UserName,
                token
            };
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Employee>>> FindAllAsync()
        {
            List<Employee> employees = await _employeeRepository.FindAllAsync();
            return Ok(employees);
        }

        [HttpGet("{userName}/{password}")]
        [Authorize]
        public async Task<ActionResult<Employee>> FindOneAsync(string userName, string password)
        {
            Employee employee = await _employeeRepository.FindOneAsync(userName, password);
            if (employee == null)
                throw new KeyNotFoundException();

            return Ok(employee);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Employee>> CreateAsync(Employee employee)
        {
            employee = await _employeeRepository.CreateAsync(employee);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employeeToUpdate)
        {
            if (id != employeeToUpdate.Id)
                return BadRequest();
            
            var updatedEmployee = await _employeeRepository.UpdateAsync(employeeToUpdate);
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteAsync(id);
            return Ok();
        }
    }
}

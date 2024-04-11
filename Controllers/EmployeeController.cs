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
            => _employeeRepository = employeeRepository;

        #region Authentication

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] Employee login)
        {
            var employee = await _employeeRepository.FindOneAsync(login.UserName, login.Password);
            if (employee == null) 
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(employee);

            return new
            {
                login = login.UserName,
                token
            };
           
        }

        #endregion

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Employee>>> FindAllAsync()
        {
            List<Employee> employees = await _employeeRepository.FindAllAsync();
            return Ok(employees);
        }
    }
}

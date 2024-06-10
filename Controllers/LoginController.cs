using Clinic.Exceptions;
using Clinic.Interfaces;
using Clinic.Interfaces.Repository;
using Clinic.Models.Login;
using Clinic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController(IEmployeeRepository employeeRepository) : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] LoginRequest loginRequest)
        {
            var employee = await _employeeRepository.FindOneAsync(loginRequest.UserName);
            if (employee == null || employee.Password != loginRequest.Password)
                throw new UnauthorizedException();

            var token = TokenService.GenerateToken(employee);

            return new
            {
                loginRequest.UserName,
                token
            };
        }

        [HttpPost("recoverpassword")]
        [AllowAnonymous]
        public async Task<ActionResult> RecoverPasswordAsync([FromBody] RecoverPasswordRequest request)
        {
            var employee = await _employeeRepository.FindOneAsync(request.UserName);

            if (employee.Password == request.NewPassword)
                throw new BadRequestException("Senha iguais, por favor informe outra senha");

            employee.Password = request.NewPassword;
            await _employeeRepository.UpdateAsync(employee);

            return Ok();
        }
    }
}

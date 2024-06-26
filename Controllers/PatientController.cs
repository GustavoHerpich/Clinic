using Clinic.Entities;
using Clinic.Interfaces.Business;
using Clinic.Models.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientBusiness _business;

        public PatientController(IPatientBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Patient>>> FindAllAsync()
        {
            List<Patient> patients = await _business.FindAllAsync();
            return Ok(patients);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Patient>> CreateAsync(PatientRequest request)
        {
            var obj = new Patient
            {
                Cpf = request.Cpf,
                Name = request.Name,
                Phone = request.Phone,
                DateOfBirth = request.DateOfBirth,
            };

            var patient = await _business.CreateAsync(obj);
            return Ok(patient);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Patient>> UpdateAsync(int id, [FromBody] PatientRequest request)
        {
            var obj = new Patient
            {
                Id = id,
                Cpf = request.Cpf,
                Name = request.Name,
                Phone = request.Phone,
                DateOfBirth = request.DateOfBirth,
            };

            var updated = await _business.UpdateAsync(obj);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Delete(int id)
        {
            await _business.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Patient>> FindById(int id)
        {
            var patient = await _business.FindById(id);

            if (patient == null)
                return NotFound();

            return Ok(patient);
        }
    }
}

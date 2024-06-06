using Clinic.Entities;
using Clinic.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _repository;

        public PatientController(IPatientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Patient>>> FindAllAsync()
        {
            List<Patient> patients = await _repository.FindAllAsync();
            return Ok(patients);
        }
    }
}

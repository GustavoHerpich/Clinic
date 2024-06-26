using Clinic.Entities;
using Clinic.Exceptions;
using Clinic.Interfaces.Business;
using Clinic.Models.Doctor;
using Clinic.Models.Employee;
using Clinic.Models.Enums;
using Clinic.Models.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorBusiness _business;

        public DoctorController(IDoctorBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Doctor>>> FindAllAsync()
        {
            List<Doctor> doctors = await _business.FindAllAsync();
            return Ok(doctors);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Doctor>> CreateAsync(DoctorRequest request)
        {
            var obj = new Doctor
            {
                CRM = request.CRM,
                Name = request.Name,
                Specialization = request.Specialization
            };

            var doctor = await _business.CreateAsync(obj);
            return Ok(doctor);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Doctor>> UpdateAsync(int id, [FromBody] DoctorRequest request)
        {
            var obj = new Doctor
            {
                Id = id,
                CRM = request.CRM,
                Name = request.Name,
                Specialization = request.Specialization
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
        public async Task<ActionResult<Doctor>> FindById(int id)
        {
            var doctor = await _business.FindById(id);

            if (doctor == null)
                return NotFound();

            return Ok(doctor);
        }
    }
}

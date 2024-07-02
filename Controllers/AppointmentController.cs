using Clinic.Entities;
using Clinic.Interfaces.Business;
using Clinic.Models.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentBusiness _business;

        public AppointmentController(IAppointmentBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<FindAppointmentModel>>> FindAllAsync()
        {
            var appointments = await _business.FindAsync();
            return Ok(appointments);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Appointment>> CreateAsync(AppointmentRequest request)
        {
            var obj = new Appointment
            {
                IdPatient = request.IdPatient,
                IdDoctor = request.IdDoctor,
                IdUser = request.IdUser,
                AppointmentDate = request.AppointmentDate
            };

            var doctor = await _business.CreateAsync(obj);
            return Ok(doctor);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Appointment>> UpdateAsync(int id, [FromBody] AppointmentRequest request)
        {
            var obj = new Appointment
            {
                Id = id,
                IdPatient = request.IdPatient,
                IdDoctor = request.IdDoctor,
                IdUser = request.IdUser,
                AppointmentDate = request.AppointmentDate
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
        public async Task<ActionResult<Appointment>> FindById(int id)
        {
            var appointment = await _business.FindById(id);

            if (appointment == null)
                return NotFound();

            return Ok(appointment);
        }
    }
}

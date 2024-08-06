using Clinic.Entities;
using Clinic.Exceptions;
using Clinic.Interfaces.Business;
using Clinic.Interfaces.Repository;
using Clinic.Models.Appointment;

namespace Clinic.Business
{
    public class AppointmentBusiness : IAppointmentBusiness
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;

        public AppointmentBusiness(IAppointmentRepository repository, 
            IEmployeeRepository employeeRepository, 
            IPatientRepository patientRepository, 
            IDoctorRepository doctorRepository)
        {
            _appointmentRepository = repository;
            _employeeRepository = employeeRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<Appointment> CreateAsync(Appointment entity)
        {
            _ = await _doctorRepository.FindById(entity.IdDoctor) ?? throw new NotFoundException("Doutor não encontrado");
            _ = await _patientRepository.FindById(entity.IdPatient) ?? throw new NotFoundException("Paciente não encontrado");
            _ = await _employeeRepository.FindById(entity.IdUser) ?? throw new NotFoundException("Usuário não encontrado");
            return await _appointmentRepository.CreateAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            return _appointmentRepository.DeleteAsync(id);
        }

        public async Task<List<Appointment>> FindAllAsync()
        {
            return await _appointmentRepository.FindAllAsync();
        }

        public async Task<Appointment> FindById(int id)
        {
            return await _appointmentRepository.FindById(id);
        }

        public async Task<Appointment> UpdateAsync(Appointment entity)
        {
            _ = await _doctorRepository.FindById(entity.IdDoctor) ?? throw new NotFoundException("Doutor não encontrado");
            _ = await _patientRepository.FindById(entity.IdPatient) ?? throw new NotFoundException("Paciente não encontrado");
            _ = await _employeeRepository.FindById(entity.IdUser) ?? throw new NotFoundException("Usuário não encontrado");
            return await _appointmentRepository.UpdateAsync(entity);
        }

        public async Task<IEnumerable<FindAppointmentModel>> FindAsync()
        {
            return await _appointmentRepository.FindAsync();
        }
    }
}

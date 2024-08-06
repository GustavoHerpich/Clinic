using Clinic.Entities;
using Clinic.Exceptions;
using Clinic.Interfaces.Business;
using Clinic.Interfaces.Repository;

namespace Clinic.Business
{
    public class PatientBusiness : IPatientBusiness
    {
        private readonly IPatientRepository _patientRepository;

        public PatientBusiness(IPatientRepository repository)
        {
            _patientRepository = repository;
        }

        public async Task<Patient> CreateAsync(Patient entity)
        {
            var find = await _patientRepository.FindByCpfAsync(entity.Cpf);

            if (find != null)
                throw new BadRequestException("Já existe cadastro para o CPF informado.");

            return await _patientRepository.CreateAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            return _patientRepository.DeleteAsync(id);
        }

        public async Task<List<Patient>> FindAllAsync()
        {
            return await _patientRepository.FindAllAsync();
        }

        public async Task<Patient> FindById(int id)
        {
            return await _patientRepository.FindById(id);
        }

        public async Task<Patient> UpdateAsync(Patient entity)
        {
            var find = await _patientRepository.FindByCpfAsync(entity.Cpf, entity.Id);

            if (find != null)
                throw new BadRequestException("Já existe cadastro para o CPF informado.");

            return await _patientRepository.UpdateAsync(entity);
        }
    }
}

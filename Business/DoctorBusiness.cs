using Clinic.Entities;
using Clinic.Exceptions;
using Clinic.Interfaces.Business;
using Clinic.Interfaces.Repository;
using Clinic.Repositories;

namespace Clinic.Business
{
    public class DoctorBusiness : IDoctorBusiness
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorBusiness(IDoctorRepository repository)
        {
            _doctorRepository = repository;
        }

        public async Task<Doctor> CreateAsync(Doctor entity)
        {
            var find = await _doctorRepository.FindByCrmAsync(entity.CRM);

            if (find != null)
                throw new BadRequestException("Já existe cadastro para o CRM informado.");

            return await _doctorRepository.CreateAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            return _doctorRepository.DeleteAsync(id);
        }

        public async Task<List<Doctor>> FindAllAsync()
        {
            return await _doctorRepository.FindAllAsync();
        }

        public async Task<Doctor> FindById(int id)
        {
            return await _doctorRepository.FindById(id);
        }

        public async Task<Doctor> UpdateAsync(Doctor entity)
        {
            var find = await _doctorRepository.FindByCrmAsync(entity.CRM, entity.Id);

            if (find != null)
                throw new BadRequestException("Já existe cadastro para o CRM informado.");

            return await _doctorRepository.UpdateAsync(entity);
        }
    }
}

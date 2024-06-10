using Clinic.Entities;
using Clinic.Data;
using Clinic.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly Context _context;

        public PatientRepository(Context context)
        {
            _context = context;
        }


        public async Task<Patient> CreateAsync(Patient entity)
        {
            await _context.Patients.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id) ?? throw new KeyNotFoundException();
            try
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<List<Patient>> FindAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> FindByCpfAsync(string cpf, int id)
        {
            var find = id == 0 ?
                       await _context.Patients.FirstOrDefaultAsync(x => x.Cpf.Equals(cpf)) :
                       await _context.Patients.FirstOrDefaultAsync(x => x.Cpf.Equals(cpf) && x.Id != id);

            return find;
        }

        public async Task<Patient> FindById(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Patient> UpdateAsync(Patient entity)
        {
            try
            {
                var find = await _context.Patients.FindAsync(entity.Id) ?? throw new KeyNotFoundException();

                _context.Entry(find).State = EntityState.Detached;
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}

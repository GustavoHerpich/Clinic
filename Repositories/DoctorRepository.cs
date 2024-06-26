using Clinic.Data;
using Clinic.Entities;
using Clinic.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly Context _context;

        public DoctorRepository(Context context)
        {
            _context = context;
        }

        public async Task<Doctor> CreateAsync(Doctor entity)
        {
            await _context.Doctors.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }


        public async Task DeleteAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id) ?? throw new KeyNotFoundException();
            try
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<List<Doctor>> FindAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> FindByCrmAsync(string crm, int id = 0)
        {
            var find = id == 0 ?
                      await _context.Doctors.FirstOrDefaultAsync(x => x.CRM.Equals(crm)) :
                      await _context.Doctors.FirstOrDefaultAsync(x => x.CRM.Equals(crm) && x.Id != id);

            return find;
        }

        public async Task<Doctor> FindById(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Doctor> UpdateAsync(Doctor entity)
        {
            try
            {
                var find = await _context.Doctors.FindAsync(entity.Id) ?? throw new KeyNotFoundException();

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

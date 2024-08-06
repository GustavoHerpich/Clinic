using Clinic.Data;
using Clinic.Entities;
using Clinic.Interfaces.Repository;
using Clinic.Models.Appointment;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly Context _context;

        public AppointmentRepository(Context context)
        {
            _context = context;
        }

        public async Task<Appointment> CreateAsync(Appointment entity)
        {
            await _context.Appointments.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }


        public async Task DeleteAsync(int id)
        {
            var Appointment = await _context.Appointments.FindAsync(id) ?? throw new KeyNotFoundException();
            try
            {
                _context.Appointments.Remove(Appointment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<List<Appointment>> FindAllAsync()
        {
            return await _context.Appointments.ToListAsync();
        }


        public async Task<Appointment> FindById(int id)
        {
            return await _context.Appointments.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Appointment> UpdateAsync(Appointment entity)
        {
            try
            {
                var find = await _context.Appointments.FindAsync(entity.Id) ?? throw new KeyNotFoundException();

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

        public async Task<IEnumerable<FindAppointmentModel>> FindAsync()
        {
            var list = new List<FindAppointmentModel>();

            var appointments = await _context.Appointments
                                .Join(
                                    _context.Doctors,
                                    apt => apt.IdDoctor,
                                    doc => doc.Id,
                                    (firstJoin, doc) => new { firstJoin, doc }
                                )
                                .Join(
                                    _context.Patients,
                                    apt => apt.firstJoin.IdPatient,
                                    pat => pat.Id,
                                    (secJoin, pat) => new { secJoin, pat }
                                )
                                .Join(
                                    _context.Employees,
                                    apt => apt.secJoin.firstJoin.IdUser,
                                    usr => usr.Id,
                                    (apt, usr) => new { 
                                        Doctor = apt.secJoin.doc,
                                        Patient = apt.pat,
                                        User = usr.UserName,
                                        AppointmentDate = apt.secJoin.firstJoin.AppointmentDate,
                                        Id = apt.secJoin.firstJoin.Id
                                    }
                                ).ToListAsync();

            foreach ( var appointment in appointments )
            {
                var item = new FindAppointmentModel
                {
                    Doctor = appointment.Doctor,
                    Patient = appointment.Patient,
                    Employee = appointment.User,
                    AppointmentDate = appointment.AppointmentDate,
                    Id = appointment.Id
                };
                list.Add(item);
            }

            return list;
        }
    }
}

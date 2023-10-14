using HappyPaws.Core.Entities;
using HappyPaws.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HappyPaws.Infrastructure.Persistence.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DatabaseContext _context;

        public DoctorRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Doctor> AddAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return doctor;
        }

        public async Task DeleteAsync(Guid id)
        {
            var fromDb = _context.Doctors.FirstOrDefault(p => p.Id == id);

            if (fromDb is null) return;

            _context.Doctors.Remove(fromDb);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetAsync(Guid id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Doctor> UpdateAsync(Guid id, Doctor doctor)
        {
            var fromDb = await GetAsync(id);

            if (fromDb != null)
            {
                fromDb.Name = doctor.Name;
                fromDb.Surname = doctor.Surname;
                fromDb.Email = doctor.Email;
                fromDb.PhoneNumber = doctor.PhoneNumber;
                fromDb.Description = doctor.Description;
                fromDb.Photo = doctor.Photo;
            }

            await _context.SaveChangesAsync();

            return fromDb;
        }
    }
}

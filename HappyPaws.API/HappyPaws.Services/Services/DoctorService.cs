using HappyPaws.Application.Interfaces;
using HappyPaws.Core.Entities;
using HappyPaws.Core.Interfaces;

namespace HappyPaws.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository dcotorRepository)
        {
            _doctorRepository = dcotorRepository;
        }

        public async Task<Doctor> AddAsync(Doctor doctor)
        {
            return await _doctorRepository.AddAsync(doctor);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _doctorRepository.DeleteAsync(id);
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _doctorRepository.GetAllAsync();
        }

        public async Task<Doctor> GetAsync(Guid id)
        {
            return await _doctorRepository.GetAsync(id);
        }

        public async Task<Doctor> UpdateAsync(Guid id, Doctor doctor)
        {
            return await _doctorRepository.UpdateAsync(id, doctor);
        }
    }
}

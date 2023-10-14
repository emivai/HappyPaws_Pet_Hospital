using HappyPaws.Core.Entities;

namespace HappyPaws.Application.Interfaces
{
    public interface IDoctorService
    {
        public Task<Doctor> AddAsync(Doctor doctor);
        public Task<Doctor> GetAsync(Guid id);
        public Task<List<Doctor>> GetAllAsync();
        public Task<Doctor> UpdateAsync(Guid id, Doctor doctor);
        public Task DeleteAsync(Guid id);
    }
}

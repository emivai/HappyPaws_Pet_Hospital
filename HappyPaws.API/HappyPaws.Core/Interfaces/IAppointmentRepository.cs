using HappyPaws.Core.Entities;

namespace HappyPaws.Core.Interfaces
{
    public interface IAppointmentRepository
    {
        public Task<Appointment> AddAsync(Appointment appointment);
        public Task<Appointment> GetAsync(Guid id);
        public Task<List<Appointment>> GetAllAsync();
        public Task<List<Appointment>> GetAllAsyncByPetId(Guid petId);
        public Task<Appointment> GetAsyncByPetId(Guid petId, Guid appointmentId);
        public Task<Appointment> UpdateAsync(Guid id, Appointment appointment);
        public Task DeleteAsync(Guid id);
    }
}

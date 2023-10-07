using HappyPaws.API.Core.Entities;

namespace HappyPaws.API.Core.Interfaces
{
    public interface IAppointmentProcedureRepository
    {
        public Task<AppointmentProcedure> AddAsync(AppointmentProcedure appointmentProcedure);
        public Task<AppointmentProcedure> GetAsync(Guid id);
        public Task<List<AppointmentProcedure>> GetAllAsync();
        public Task<AppointmentProcedure> UpdateAsync(Guid id, AppointmentProcedure appointmentProcedure);
        public Task DeleteAsync(Guid id);
    }
}

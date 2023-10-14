using HappyPaws.Application.Interfaces;
using HappyPaws.Core.Entities;
using HappyPaws.Core.Interfaces;

namespace HappyPaws.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Appointment> AddAsync(Appointment appointment)
        {
            return await _appointmentRepository.AddAsync(appointment);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _appointmentRepository.DeleteAsync(id);
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _appointmentRepository.GetAllAsync();
        }

        public async Task<Appointment> GetAsync(Guid id)
        {
            return await _appointmentRepository.GetAsync(id);
        }

        public async Task<Appointment> UpdateAsync(Guid id, Appointment appointment)
        {
            return await _appointmentRepository.UpdateAsync(id, appointment);
        }
    }
}

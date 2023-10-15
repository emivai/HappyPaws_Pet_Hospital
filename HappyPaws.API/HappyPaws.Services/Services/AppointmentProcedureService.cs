using HappyPaws.Application.Interfaces;
using HappyPaws.Core.Entities;
using HappyPaws.Core.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace HappyPaws.Application.Services
{
    public class AppointmentProcedureService : IAppointmentProcedureService
    {
        private readonly IAppointmentProcedureRepository _appointmentProcedureRepository;

        public AppointmentProcedureService(IAppointmentProcedureRepository appointmentProcedureRepository)
        {
            _appointmentProcedureRepository = appointmentProcedureRepository;
        }

        public async Task<AppointmentProcedure> AddAsync(AppointmentProcedure appointmentProcedure)
        {
            return await _appointmentProcedureRepository.AddAsync(appointmentProcedure);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _appointmentProcedureRepository.DeleteAsync(id);
        }

        public async Task<List<AppointmentProcedure>> GetAllAsync()
        {
            return await _appointmentProcedureRepository.GetAllAsync();
        }

        public async Task<AppointmentProcedure> GetAsync(Guid id)
        {
            return await _appointmentProcedureRepository.GetAsync(id);
        }

        public async Task<AppointmentProcedure> UpdateAsync(Guid id, AppointmentProcedure appointmentProcedure)
        {
            return await _appointmentProcedureRepository.UpdateAsync(id, appointmentProcedure);
        }
    }
}

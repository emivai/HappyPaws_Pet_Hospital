using HappyPaws.Core.Entities;

namespace HappyPaws.Application.Interfaces
{
    public interface INoteService
    {
        public Task<Note> AddAsync(Note note);
        public Task<Note> GetAsync(Guid id);
        public Task<List<Note>> GetAllAsync();
        public Task<List<Note>> GetAllAsyncByPetAndAppointmentId(Guid petId, Guid appointmentId);

        public Task<Note> GetAsyncByPetAndAppointmentId(Guid petId, Guid appointmentId, Guid noteId);
        public Task<Note> UpdateAsync(Guid id, Note note);
        public Task DeleteAsync(Guid id);
    }
}

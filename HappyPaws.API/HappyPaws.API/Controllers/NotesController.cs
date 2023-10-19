using HappyPaws.API.Contracts.DTOs.NoteDTOs;
using HappyPaws.Application.Interfaces;
using HappyPaws.Core.Exceptions.Common;
using Microsoft.AspNetCore.Mvc;

namespace HappyPaws.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;
        private readonly IAppointmentService _appointmentService;
        private readonly IPetService _petService;

        public NotesController(INoteService noteService, IAppointmentService appointmentService, IPetService petService)
        {
            _noteService = noteService;
            _appointmentService = appointmentService;
            _petService = petService;
        }

        [Route("[controller]")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<NoteDTO>), (StatusCodes.Status200OK))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync()
        {
            var notes = await _noteService.GetAllAsync();

            var result = notes.Select(NoteDTO.FromDomain).ToList();

            return Ok(result);
        }

        [HttpGet("[controller]/{id}")]
        [ProducesResponseType(typeof(NoteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var note = await _noteService.GetAsync(id);

            if (note == null) throw new NotFoundException("Note", id);

            return Ok(note);
        }

        [Route("[controller]")]
        [HttpPost]
        [ProducesResponseType(typeof(NoteDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateNoteDTO noteDTO)
        {
            var appointment = await _appointmentService.GetAsync(noteDTO.AppointmentId);

            if (appointment == null) throw new NotFoundException("Appointment", noteDTO.AppointmentId);

            var created = await _noteService.AddAsync(CreateNoteDTO.ToDomain(noteDTO));

            return StatusCode(StatusCodes.Status201Created, NoteDTO.FromDomain(created));
        }

        [HttpPut("[controller]/{id}")]
        [ProducesResponseType(typeof(NoteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateNoteDTO noteDTO)
        {
            var note = _noteService.GetAsync(id);

            if (note == null) throw new NotFoundException("Note", id);

            var updated = await _noteService.UpdateAsync(id, UpdateNoteDTO.ToDomain(noteDTO));

            return Ok(NoteDTO.FromDomain(updated));
        }

        [Route("[controller]")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var note = _noteService.GetAsync(id);

            if (note == null) throw new NotFoundException("Note", id);

            await _noteService.DeleteAsync(id);

            return NoContent();
        }

        [Route("Pets/{petId}/Appointments/{appointmentId}/[controller]")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<NoteDTO>), (StatusCodes.Status200OK))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByPetIdAndAppointmentIdAsync(Guid petId, Guid appointmentId)
        {
            var pet = await _petService.GetAsync(petId);

            if (pet == null) throw new NotFoundException("Pet", petId);

            var appointment = await _appointmentService.GetAsync(appointmentId);

            if (appointment == null) throw new NotFoundException("Appointment", appointmentId);

            var notes = await _noteService.GetAllAsyncByPetAndAppointmentId(petId, appointmentId);

            var result = notes.Select(NoteDTO.FromDomain).ToList();

            return Ok(result);
        }

        [Route("Pets/{petId}/Appointments/{appointmentId}/[controller]/{noteId}")]
        [HttpGet]
        [ProducesResponseType(typeof(NoteDTO), (StatusCodes.Status200OK))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByPetIdAndAppointmentIdAsync(Guid petId, Guid appointmentId, Guid noteId)
        {
            var pet = await _petService.GetAsync(petId);

            if (pet == null) throw new NotFoundException("Pet", petId);

            var appointment = await _appointmentService.GetAsync(appointmentId);

            if (appointment == null) throw new NotFoundException("Appointment", appointmentId);

            var note = await _noteService.GetAsyncByPetAndAppointmentId(petId, appointmentId, noteId);

            if (note == null) throw new NotFoundException("Note", noteId);

            return Ok(note);
        }

        [Route("Pets/{petId}/Appointments/{appointmentId}/[controller]")]
        [HttpPost]
        [ProducesResponseType(typeof(NoteDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsyncByPetIdAndAppointmentIdAsync(Guid petId, Guid appointmentId, CreateNoteDTO noteDTO)
        {
            var appointment = await _appointmentService.GetAsync(noteDTO.AppointmentId);

            if (appointment == null) throw new NotFoundException("Appointment", noteDTO.AppointmentId);

            var created = await _noteService.AddAsync(CreateNoteDTO.ToDomain(noteDTO));

            return StatusCode(StatusCodes.Status201Created, NoteDTO.FromDomain(created));
        }

        [HttpPut("Pets/{petId}/Appointments/{appointmentId}/[controller]/{noteId}")]
        [ProducesResponseType(typeof(NoteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsyncByPetIdAndAppointmentIdAsync(Guid petId, Guid appointmentId, Guid noteId, UpdateNoteDTO noteDTO)
        {
            var note = _noteService.GetAsync(noteId);

            if (note == null) throw new NotFoundException("Note", noteId);

            var updated = await _noteService.UpdateAsync(noteId, UpdateNoteDTO.ToDomain(noteDTO));

            return Ok(NoteDTO.FromDomain(updated));
        }

        [Route("Pets/{petId}/Appointments/{appointmentId}/[controller]/{noteId}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsyncByPetIdAndAppointmentIdAsync(Guid petId, Guid appointmentId, Guid noteId)
        {
            var note = _noteService.GetAsync(noteId);

            if (note == null) throw new NotFoundException("Note", noteId);

            await _noteService.DeleteAsync(noteId);

            return NoContent();
        }
    }
}

using HappyPaws.API.Contracts.DTOs.NoteDTOs;
using HappyPaws.Application.Interfaces;
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

            if (note == null) return NotFound($"Note with id {id} does not exist.");

            return Ok(note);
        }

        [Route("Pets/{petId}/Appointments/{appointmentId}/[controller]")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<NoteDTO>), (StatusCodes.Status200OK))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByPetIdAndAppointmentIdAsync(Guid petId, Guid appointmentId)
        {
            var pet = await _petService.GetAsync(petId);

            if (pet == null) return BadRequest("Invalid PetId. No such pet exists.");

            var appointment = await _appointmentService.GetAsync(appointmentId);

            if (appointment == null) return BadRequest("Invalid AppointmentId. No such appointment exists.");

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

            if (pet == null) return BadRequest("Invalid PetId. No such pet exists.");

            var appointment = await _appointmentService.GetAsync(appointmentId);

            if (appointment == null) return BadRequest("Invalid AppointmentId. No such appointment exists.");

            var note = await _noteService.GetAsyncByPetAndAppointmentId(petId, appointmentId, noteId);

            if(note == null) return NotFound($"Note with id {noteId} does not exist.");

            return Ok(note);
        }

        [Route("[controller]")]
        [HttpPost]
        [ProducesResponseType(typeof(NoteDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateNoteDTO noteDTO)
        {
            var appointment = await _appointmentService.GetAsync(noteDTO.AppointmentId);

            if (appointment == null) return BadRequest("Invalid AppointmentId. No such appointment exists.");

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

            if (note == null) return NotFound($"Note with id {id} does not exist.");

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

            if (note == null) return NotFound($"Note with id {id} does not exist.");

            await _noteService.DeleteAsync(id);

            return NoContent();
        }
    }
}

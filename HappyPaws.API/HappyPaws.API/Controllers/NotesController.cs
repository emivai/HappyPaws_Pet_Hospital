using HappyPaws.API.Contracts.DTOs.NoteDTOs;
using HappyPaws.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HappyPaws.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<NoteDTO>), (StatusCodes.Status200OK))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync()
        {
            var notes = await _noteService.GetAllAsync();

            var result = notes.Select(NoteDTO.FromDomain).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(NoteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var note = await _noteService.GetAsync(id);

            return Ok(NoteDTO.FromDomain(note));
        }

        [HttpPost]
        [ProducesResponseType(typeof(NoteDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateNoteDTO noteDTO)
        {
            var created = await _noteService.AddAsync(CreateNoteDTO.ToDomain(noteDTO));

            return StatusCode(StatusCodes.Status201Created, NoteDTO.FromDomain(created));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(NoteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateNoteDTO noteDTO)
        {
            var note = _noteService.GetAsync(id);

            if (note == null) return NotFound();

            var updated = await _noteService.UpdateAsync(id, UpdateNoteDTO.ToDomain(noteDTO));

            return Ok(NoteDTO.FromDomain(updated));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var note = _noteService.GetAsync(id);

            if (note == null) return NotFound();

            await _noteService.DeleteAsync(id);

            return NoContent();
        }
    }
}

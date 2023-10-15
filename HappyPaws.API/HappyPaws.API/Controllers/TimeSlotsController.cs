using HappyPaws.API.Contracts.DTOs.TimeSlotDTOs;
using HappyPaws.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HappyPaws.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class TimeSlotsController : ControllerBase
    {
        private readonly ITimeSlotService _timeSlotService;

        public TimeSlotsController(ITimeSlotService timeSlotService)
        {
            _timeSlotService = timeSlotService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TimeSlotDTO>), (StatusCodes.Status200OK))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync()
        {
            var timeSlots = await _timeSlotService.GetAllAsync();

            var result = timeSlots.Select(TimeSlotDTO.FromDomain).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TimeSlotDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var timeSlot = await _timeSlotService.GetAsync(id);

            return Ok(TimeSlotDTO.FromDomain(timeSlot));
        }

        [HttpPost]
        [ProducesResponseType(typeof(TimeSlotDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateTimeSlotDTO timeSlotDTO)
        {
            var created = await _timeSlotService.AddAsync(CreateTimeSlotDTO.ToDomain(timeSlotDTO));

            return StatusCode(StatusCodes.Status201Created, TimeSlotDTO.FromDomain(created));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TimeSlotDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateTimeSlotDTO timeSlotDTO)
        {
            var timeSlot = _timeSlotService.GetAsync(id);

            if (timeSlot == null) return NotFound();

            var updated = await _timeSlotService.UpdateAsync(id, UpdateTimeSlotDTO.ToDomain(timeSlotDTO));

            return Ok(TimeSlotDTO.FromDomain(updated));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var timeSlot = _timeSlotService.GetAsync(id);

            if (timeSlot == null) return NotFound();

            await _timeSlotService.DeleteAsync(id);

            return NoContent();
        }
    }
}

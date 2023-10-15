using HappyPaws.API.Contracts.DTOs.TimeSlotDTOs;
using HappyPaws.Application.Interfaces;
using HappyPaws.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace HappyPaws.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class TimeSlotsController : ControllerBase
    {
        private readonly ITimeSlotService _timeSlotService;
        private readonly IUserService _userService;

        public TimeSlotsController(ITimeSlotService timeSlotService, IUserService userService)
        {
            _timeSlotService = timeSlotService;
            _userService = userService;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var timeSlot = await _timeSlotService.GetAsync(id);

            if (timeSlot == null) return NotFound($"Time slot with id {id} does not exist.");

            return Ok(TimeSlotDTO.FromDomain(timeSlot));
        }

        [HttpPost]
        [ProducesResponseType(typeof(TimeSlotDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateTimeSlotDTO timeSlotDTO)
        {
            var doctor = await _userService.GetAsync(timeSlotDTO.DoctorId);

            if (doctor == null) 
                return BadRequest("Invalid DoctorId. No such user exists.");

            if(doctor.Type != UserType.Doctor) 
                return BadRequest("Invalid DoctorId. User has to be of type doctor.");

            var timeSlots = await _timeSlotService.GetAllAsync();

            if (timeSlots.Exists(t => t.DoctorId == timeSlotDTO.DoctorId && t.Start == timeSlotDTO.Start && t.End == timeSlotDTO.End)) 
                return BadRequest("Doctor cannot have timeslots repeated.");

            if (timeSlots.Exists(t => t.DoctorId == timeSlotDTO.DoctorId && t.Start < timeSlotDTO.End && timeSlotDTO.Start < t.End))
                return BadRequest("Doctor cannot have timeslots overlapping.");

            var created = await _timeSlotService.AddAsync(CreateTimeSlotDTO.ToDomain(timeSlotDTO));

            return StatusCode(StatusCodes.Status201Created, TimeSlotDTO.FromDomain(created));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TimeSlotDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateTimeSlotDTO timeSlotDTO)
        {
            var timeSlot = await _timeSlotService.GetAsync(id);

            var doctor = await _userService.GetAsync(timeSlotDTO.DoctorId);

            if (doctor == null) 
                return BadRequest("Invalid DoctorId. No such user exists.");

            if (doctor.Type != UserType.Doctor) 
                return BadRequest("Invalid DoctorId. User has to be of type doctor.");

            if (timeSlot == null) 
                return NotFound($"Time slot with id {id} does not exist.");

            var timeSlots = await _timeSlotService.GetAllAsync();

            if (timeSlots.Exists(t => t.DoctorId == timeSlotDTO.DoctorId && t.Start == timeSlotDTO.Start && t.End == timeSlotDTO.End))
                return BadRequest("Doctor cannot have timeslots repeated.");

            if (timeSlots.Exists(t => t.DoctorId == timeSlotDTO.DoctorId && t.Start < timeSlotDTO.End && timeSlotDTO.Start < t.End))
                return BadRequest("Doctor cannot have timeslots overlapping.");

            var updated = await _timeSlotService.UpdateAsync(id, UpdateTimeSlotDTO.ToDomain(timeSlotDTO));

            return Ok(TimeSlotDTO.FromDomain(updated));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var timeSlot = await _timeSlotService.GetAsync(id);

            if (timeSlot == null) return NotFound($"Time slot with id {id} does not exist.");

            await _timeSlotService.DeleteAsync(id);

            return NoContent();
        }
    }
}

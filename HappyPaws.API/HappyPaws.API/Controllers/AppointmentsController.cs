using HappyPaws.API.Contracts.DTOs.AppointmentDTOs;
using HappyPaws.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HappyPaws.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentsService;
        private readonly ITimeSlotService _timeSlotService;
        private readonly IPetService _petService;

        public AppointmentsController(IAppointmentService appointmentsService, ITimeSlotService timeSlotService, IPetService petService)
        {
            _appointmentsService = appointmentsService;
            _timeSlotService = timeSlotService;
            _petService = petService;
        }

        [HttpGet]
        [Route("[controller]")]
        [ProducesResponseType(typeof(IEnumerable<AppointmentDTO>), (StatusCodes.Status200OK))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync()
        {
            var appointments = await _appointmentsService.GetAllAsync();

            var result = appointments.Select(AppointmentDTO.FromDomain).ToList();

            return Ok(result);
        }


        [HttpGet("[controller]/{id}")]
        [ProducesResponseType(typeof(AppointmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var appointment = await _appointmentsService.GetAsync(id);

            if (appointment == null) return NotFound($"Appointment with id {id} does not exist.");

            return Ok(AppointmentDTO.FromDomain(appointment));
        }

        [HttpGet("Pets/{petId}/[controller]")]
        [ProducesResponseType(typeof(IEnumerable<AppointmentDTO>), (StatusCodes.Status200OK))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsyncByPetId(Guid petId)
        {
            var pet = await _petService.GetAsync(petId);

            if (pet == null) return BadRequest("Invalid PetId. No such pet exists");

            var appointments = await _appointmentsService.GetAllAsyncByPetId(petId);

            var result = appointments.Select(AppointmentDTO.FromDomain).ToList();

            return Ok(result);
        }
        [HttpGet("Pets/{petId}/[controller]/{appointmentId}")]
        [ProducesResponseType(typeof(AppointmentDTO), (StatusCodes.Status200OK))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsyncByPetId(Guid petId, Guid appointmentId)
        {
            var pet = await _petService.GetAsync(petId);

            if (pet == null) return BadRequest("Invalid PetId. No such pet exists");

            var appointment = await _appointmentsService.GetAsyncByPetId(petId, appointmentId);

            return Ok(AppointmentDTO.FromDomain(appointment));
        }

        [Route("[controller]")]
        [HttpPost]
        [ProducesResponseType(typeof(AppointmentDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateAppointmentDTO appointmentDTO)
        {
            var timeSlot = await _timeSlotService.GetAsync(appointmentDTO.TimeSlotId);

            if (timeSlot == null) return BadRequest("Invalid TimeSlotId. No such time slot exists");

            var pet = await _petService.GetAsync(appointmentDTO.PetId);

            if (pet == null) return BadRequest("Invalid PetId. No such pet exists");

            var created = await _appointmentsService.AddAsync(CreateAppointmentDTO.ToDomain(appointmentDTO));

            return StatusCode(StatusCodes.Status201Created, AppointmentDTO.FromDomain(created));
        }

        [HttpPut("[controller]/{id}")]
        [ProducesResponseType(typeof(AppointmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateAppointmentDTO appointmentDTO)
        {
            var appointment = _appointmentsService.GetAsync(id);

            if (appointment == null) return NotFound($"Appointment with id {id} does not exist.");

            var timeSlot = await _timeSlotService.GetAsync(appointmentDTO.TimeSlotId);

            if (timeSlot == null) return BadRequest("Invalid TimeSlotId. No such time slot exists");

            var pet = await _petService.GetAsync(appointmentDTO.PetId);

            if (pet == null) return BadRequest("Invalid PetId. No such pet exists");

            var updated = await _appointmentsService.UpdateAsync(id, UpdateAppointmentDTO.ToDomain(appointmentDTO));

            return Ok(AppointmentDTO.FromDomain(updated));
        }

        [Route("[controller]")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var appointment = _appointmentsService.GetAsync(id);

            if (appointment == null) return NotFound($"Appointment with id {id} does not exist.");

            await _appointmentsService.DeleteAsync(id);

            return NoContent();
        }
    }
}

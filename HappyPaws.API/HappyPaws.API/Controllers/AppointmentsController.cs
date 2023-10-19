using HappyPaws.API.Contracts.DTOs.AppointmentDTOs;
using HappyPaws.Application.Interfaces;
using HappyPaws.Core.Entities;
using HappyPaws.Core.Exceptions.Common;
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

            if (appointment == null) throw new NotFoundException("Appointment", id);

            return Ok(AppointmentDTO.FromDomain(appointment));
        }

        [Route("[controller]")]
        [HttpPost]
        [ProducesResponseType(typeof(AppointmentDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateAppointmentDTO appointmentDTO)
        {
            var timeSlot = await _timeSlotService.GetAsync(appointmentDTO.TimeSlotId);

            if (timeSlot == null) throw new NotFoundException("Time slot", appointmentDTO.TimeSlotId);

            var pet = await _petService.GetAsync(appointmentDTO.PetId);

            if (pet == null) throw new NotFoundException("Pet", appointmentDTO.PetId);

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

            if (appointment == null) throw new NotFoundException("Appointment", id);

            var timeSlot = await _timeSlotService.GetAsync(appointmentDTO.TimeSlotId);

            if (timeSlot == null) throw new NotFoundException("Time slot", appointmentDTO.TimeSlotId);

            var pet = await _petService.GetAsync(appointmentDTO.PetId);

            if (pet == null) throw new NotFoundException("Pet", appointmentDTO.PetId);

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

            if (appointment == null) throw new NotFoundException("Appointment", id);

            await _appointmentsService.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("Pets/{petId}/[controller]")]
        [ProducesResponseType(typeof(IEnumerable<AppointmentDTO>), (StatusCodes.Status200OK))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsyncByPetId(Guid petId)
        {
            var pet = await _petService.GetAsync(petId);

            if (pet == null) throw new NotFoundException("Pet", petId);

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

            if (pet == null) throw new NotFoundException("Pet", petId);

            var appointment = await _appointmentsService.GetAsyncByPetId(petId, appointmentId);

            return Ok(AppointmentDTO.FromDomain(appointment));
        }

        [Route("Pets/{petId}/[controller]")]
        [HttpPost]
        [ProducesResponseType(typeof(AppointmentDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsyncByPetId(CreateAppointmentDTO appointmentDTO)
        {
            var timeSlot = await _timeSlotService.GetAsync(appointmentDTO.TimeSlotId);

            if (timeSlot == null) throw new NotFoundException("Time slot", appointmentDTO.TimeSlotId);

            var pet = await _petService.GetAsync(appointmentDTO.PetId);

            if (pet == null) throw new NotFoundException("Pet", appointmentDTO.PetId);

            var created = await _appointmentsService.AddAsync(CreateAppointmentDTO.ToDomain(appointmentDTO));

            return StatusCode(StatusCodes.Status201Created, AppointmentDTO.FromDomain(created));
        }

        [HttpPut("Pets/{petId}/[controller]/{appointmentId}")]
        [ProducesResponseType(typeof(AppointmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsyncByPetId(Guid petId, Guid appointmentId, UpdateAppointmentDTO appointmentDTO)
        {
            var appointment = _appointmentsService.GetAsync(appointmentId);

            if (appointment == null) throw new NotFoundException("Appointment", appointmentId);

            var pet = await _petService.GetAsync(petId);

            if (pet == null) throw new NotFoundException("Pet", petId);

            var timeSlot = await _timeSlotService.GetAsync(appointmentDTO.TimeSlotId);

            if (timeSlot == null) throw new NotFoundException("Time slot", appointmentDTO.TimeSlotId);

            var updated = await _appointmentsService.UpdateAsync(appointmentId, UpdateAppointmentDTO.ToDomain(appointmentDTO));

            return Ok(AppointmentDTO.FromDomain(updated));
        }

        [Route("Pets/{petId}/[controller]/{appointmentId}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsyncByPetId(Guid petId, Guid appointmentId)
        {
            var appointment = _appointmentsService.GetAsync(appointmentId);

            if (appointment == null) throw new NotFoundException("Appointment", appointmentId);

            var pet = await _petService.GetAsync(petId);

            if (pet == null) throw new NotFoundException("Pet", petId);

            await _appointmentsService.DeleteAsync(appointmentId);

            return NoContent();
        }
    }
}

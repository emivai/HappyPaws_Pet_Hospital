using HappyPaws.API.Contracts.DTOs.AppointmentDTOs;
using HappyPaws.API.Contracts.DTOs.AppointmentProcedureDTOs;
using HappyPaws.API.Contracts.DTOs.PetDTOs;
using HappyPaws.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HappyPaws.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentsService;

        public AppointmentsController(IAppointmentService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AppointmentDTO>), (StatusCodes.Status200OK))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync()
        {
            var appointments = await _appointmentsService.GetAllAsync();

            var result = appointments.Select(AppointmentDTO.FromDomain).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AppointmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var appointment = await _appointmentsService.GetAsync(id);

            if (appointment == null) return NotFound();

            return Ok(AppointmentDTO.FromDomain(appointment));
        }

        [HttpPost]
        [ProducesResponseType(typeof(AppointmentDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateAppointmentDTO appointmentDTO)
        {
            var created = await _appointmentsService.AddAsync(CreateAppointmentDTO.ToDomain(appointmentDTO));

            return StatusCode(StatusCodes.Status201Created, AppointmentDTO.FromDomain(created));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AppointmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateAppointmentDTO appointmentDTO)
        {
            var appointment = _appointmentsService.GetAsync(id);

            if (appointment == null) return NotFound();

            var updated = await _appointmentsService.UpdateAsync(id, UpdateAppointmentDTO.ToDomain(appointmentDTO));

            return Ok(AppointmentDTO.FromDomain(updated));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var appointment = _appointmentsService.GetAsync(id);

            if (appointment == null) return NotFound();

            await _appointmentsService.DeleteAsync(id);

            return NoContent();
        }
    }
}

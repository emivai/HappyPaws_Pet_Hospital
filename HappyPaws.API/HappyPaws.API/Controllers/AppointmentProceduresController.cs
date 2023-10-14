using HappyPaws.API.Contracts.DTOs.AppointmentDTOs;
using HappyPaws.API.Contracts.DTOs.AppointmentProcedureDTOs;
using HappyPaws.Application.Interfaces;
using HappyPaws.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HappyPaws.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class AppointmentProceduresController : ControllerBase
    {
        private readonly IAppointmentProcedureService _appointmentProceduresService;

        public AppointmentProceduresController(IAppointmentProcedureService appointmentProceduresService)
        {
            _appointmentProceduresService = appointmentProceduresService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AppointmentProcedureDTO>), (StatusCodes.Status200OK))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync()
        {
            var appointmentProcedures = await _appointmentProceduresService.GetAllAsync();

            var result = appointmentProcedures.Select(AppointmentProcedureDTO.FromDomain).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AppointmentProcedureDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var appointmentProcedure = await _appointmentProceduresService.GetAsync(id);

            return Ok(AppointmentProcedureDTO.FromDomain(appointmentProcedure));
        }

        [HttpPost]
        [ProducesResponseType(typeof(AppointmentProcedureDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateAppointmentProcedureDTO appointmentProcedureDTO)
        {
            var created = await _appointmentProceduresService.AddAsync(CreateAppointmentProcedureDTO.ToDomain(appointmentProcedureDTO));

            return StatusCode(StatusCodes.Status201Created, AppointmentProcedureDTO.FromDomain(created));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AppointmentProcedureDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateAppointmentProcedureDTO appointmentProcedureDTO)
        {
            var appointmentProcedure = _appointmentProceduresService.GetAsync(id);

            if (appointmentProcedure == null) return NotFound();

            var updated = await _appointmentProceduresService.UpdateAsync(id, UpdateAppointmentProcedureDTO.ToDomain(appointmentProcedureDTO));

            return Ok(AppointmentProcedureDTO.FromDomain(updated));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var appointmentProcedure = _appointmentProceduresService.GetAsync(id);

            if (appointmentProcedure == null) return NotFound();

            await _appointmentProceduresService.DeleteAsync(id);

            return NoContent();
        }
    }
}

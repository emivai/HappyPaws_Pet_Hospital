using HappyPaws.API.Contracts.DTOs.AppointmentProcedureDTOs;
using HappyPaws.Application.Interfaces;
using HappyPaws.Core.Exceptions.Common;
using Microsoft.AspNetCore.Mvc;

namespace HappyPaws.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class AppointmentProceduresController : ControllerBase
    {
        private readonly IAppointmentProcedureService _appointmentProceduresService;
        private readonly IAppointmentService _appointmentsService;
        private readonly IProcedureService _proceduresService;

        public AppointmentProceduresController(IAppointmentProcedureService appointmentProceduresService, 
                                                IAppointmentService appointmentsService, 
                                                IProcedureService proceduresService)
        {
            _appointmentProceduresService = appointmentProceduresService;
            _appointmentsService = appointmentsService;
            _proceduresService = proceduresService;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var appointmentProcedure = await _appointmentProceduresService.GetAsync(id);

            if (appointmentProcedure == null) throw new ResourceNotFoundException();

            return Ok(AppointmentProcedureDTO.FromDomain(appointmentProcedure));
        }

        [HttpPost]
        [ProducesResponseType(typeof(AppointmentProcedureDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateAppointmentProcedureDTO appointmentProcedureDTO)
        {
            var appointment = await _appointmentsService.GetAsync(appointmentProcedureDTO.AppointmentId);

            if (appointment == null) throw new ResourceNotFoundException();

            var procedure = await _proceduresService.GetAsync(appointmentProcedureDTO.ProcedureId);

            if (procedure == null) throw new ResourceNotFoundException();

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

            if (appointmentProcedure == null) throw new ResourceNotFoundException();

            var appointment = await _appointmentsService.GetAsync(appointmentProcedureDTO.AppointmentId);

            if (appointment == null) throw new ResourceNotFoundException();

            var procedure = await _proceduresService.GetAsync(appointmentProcedureDTO.ProcedureId);

            if (procedure == null) throw new ResourceNotFoundException();

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

            if (appointmentProcedure == null) throw new ResourceNotFoundException();

            await _appointmentProceduresService.DeleteAsync(id);

            return NoContent();
        }
    }
}

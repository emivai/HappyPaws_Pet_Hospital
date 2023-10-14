using HappyPaws.API.Contracts.DTOs.AppointmentProcedureDTOs;
using HappyPaws.API.Contracts.DTOs.DoctorDTOs;
using HappyPaws.Application.Interfaces;
using HappyPaws.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HappyPaws.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DoctorDTO>), (StatusCodes.Status200OK))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync()
        {
            var doctors = await _doctorService.GetAllAsync();

            var result = doctors.Select(DoctorDTO.FromDomain).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var doctor = await _doctorService.GetAsync(id);

            return Ok(DoctorDTO.FromDomain(doctor));
        }

        [HttpPost]
        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateDoctorDTO doctorDTO)
        {
            var created = await _doctorService.AddAsync(CreateDoctorDTO.ToDomain(doctorDTO));

            return StatusCode(StatusCodes.Status201Created, DoctorDTO.FromDomain(created));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateDoctorDTO doctorDTO)
        {
            var doctor = _doctorService.GetAsync(id);

            if (doctor == null) return NotFound();

            var updated = await _doctorService.UpdateAsync(id, UpdateDoctorDTO.ToDomain(doctorDTO));

            return Ok(DoctorDTO.FromDomain(updated));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var doctor = _doctorService.GetAsync(id);

            if (doctor == null) return NotFound();

            await _doctorService.DeleteAsync(id);

            return NoContent();
        }
    }
}

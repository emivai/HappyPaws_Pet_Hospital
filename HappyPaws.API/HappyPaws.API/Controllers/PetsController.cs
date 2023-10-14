using HappyPaws.API.Contracts.DTOs.PetDTOs;
using HappyPaws.API.Contracts.DTOs.UserDTOs;
using HappyPaws.Application.Interfaces;
using HappyPaws.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HappyPaws.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petsService;

        public PetsController(IPetService petsService)
        {
            _petsService = petsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PetDTO>), (StatusCodes.Status200OK))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync()
        {
            var pets = await _petsService.GetAllAsync();

            var result = pets.Select(PetDTO.FromDomain).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PetDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var pet = await _petsService.GetAsync(id);

            return Ok(PetDTO.FromDomain(pet));
        }

        [HttpPost]
        [ProducesResponseType(typeof(PetDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreatePetDTO petDTO)
        {
            var created = await _petsService.AddAsync(CreatePetDTO.ToDomain(petDTO));

            return StatusCode(StatusCodes.Status201Created, PetDTO.FromDomain(created));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PetDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdatePetDTO userDTO)
        {
            var pet = _petsService.GetAsync(id);

            if (pet == null) return NotFound();

            var updated = await _petsService.UpdateAsync(id, UpdatePetDTO.ToDomain(userDTO));

            return Ok(PetDTO.FromDomain(updated));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var pet = _petsService.GetAsync(id);

            if (pet == null) return NotFound();

            await _petsService.DeleteAsync(id);

            return NoContent();
        }
    }
}

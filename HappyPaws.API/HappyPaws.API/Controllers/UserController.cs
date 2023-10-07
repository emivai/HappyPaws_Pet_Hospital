using HappyPaws.API.Contracts.Responses;
using HappyPaws.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HappyPaws.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ProducesAttribute("application/json")]

    public class UserController : ControllerBase
    {
        private readonly IUserService _usersService;

        public UserController(IUserService usersSerevice) 
        {
            _usersService = usersSerevice;
        }

        [HttpGet]
        [ActionName("getAll")]
        public async Task<IActionResult> Get()
        {
            var users = await _usersService.GetAllAsync();

            var result = users.Select(UserResponse.FromDomain).ToList();

            return Ok(result);
        }
    }
}

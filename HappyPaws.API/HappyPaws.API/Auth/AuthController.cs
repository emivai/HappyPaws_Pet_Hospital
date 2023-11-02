
using FluentValidation;
using HappyPaws.API.Contracts.DTOs.UserDTOs;
using HappyPaws.API.Controllers;
using HappyPaws.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyPaws.API.Auth
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ITokenManager _tokenManager;
        private readonly IValidator<CreateUserDTO> _validator;
        public AuthController(IUserService userService, ITokenManager tokenManager, IValidator<CreateUserDTO> validator)
        {
            _userService = userService;
            _tokenManager = tokenManager;
            _validator = validator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginUserDTO loginUserDTO)
        {
            return Ok(await _userService.LoginAsync(loginUserDTO));
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(CreateUserDTO createUserDTO)
        {
            var result = _validator.Validate(createUserDTO);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(errorMessages);
            }

            await _userService.AddAsync(CreateUserDTO.ToDomain(createUserDTO));

            return Ok();
        }

        [HttpGet]
        [Authorize]
        [Route("currentUser")]
        public async Task<IActionResult> CurrentUser()
        {
            var bearerToken = Request.Headers["authorization"].ToString().Replace("Bearer ", "");
            var token = _tokenManager.DecodeAccessTokenAsync(bearerToken);

            if (token == null || token.ValidFrom > DateTime.UtcNow || token.ValidTo < DateTime.UtcNow)
            {
                return Unauthorized();
            }

            var userId = GetUserId();

            return Ok(await _userService.GetAsync(userId));
        }
    }
}

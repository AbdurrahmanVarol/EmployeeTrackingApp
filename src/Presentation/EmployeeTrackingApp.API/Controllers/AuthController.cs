using EmployeeTrackingApp.Application.Interfaces.Services;
using EmployeeTrackingApp.Application.Models;
using EmployeeTrackingApp.Application.Responses;
using EmployeeTrackingApp.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;

namespace EmployeeTrackingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private IAuthService _authService;

        private Guid UserId => Guid.Parse(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).First().Value);
        private UserRole UserRole => (UserRole)int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.Role).First().Value);

        public AuthController(IMediator mediator, IAuthService authService)
        {
            _mediator = mediator;
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _authService.LoginAsync(loginModel);


            return Ok(result);
        }
        [HttpPost("Refresh")]
        public async Task<ActionResult<LoginResponse>> Refresh([FromBody] RefreshTokenModel refreshToken)
        {
            return await _authService.RefreshTokenAsync(refreshToken.RefreshToken, UserId);
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserModel userModel)
        {
            await _authService.RegisterAsync(userModel);

            return Ok(new { IsSuccess = true });
        }
    }
}

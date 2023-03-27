using EmployeeTrackingApp.Application.Features.Queries.GetAllDepartments;
using EmployeeTrackingApp.Application.Features.Queries.GetUserByUserName;
using EmployeeTrackingApp.Application.Interfaces.Services;
using EmployeeTrackingApp.Application.Models;
using EmployeeTrackingApp.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
           var token = await _authService.Login(loginModel);

            
            return Ok(new {IsSuccess = !string.IsNullOrWhiteSpace(token),token});
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserModel userModel)
        {
            await _authService.Register(userModel);
            
            return Ok(new {IsSuccess=true});
        }
    }
}

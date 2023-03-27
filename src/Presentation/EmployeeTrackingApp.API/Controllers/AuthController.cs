using EmployeeTrackingApp.Application.Features.Queries.GetUserByUserName;
using EmployeeTrackingApp.Application.Interfaces.Services;
using EmployeeTrackingApp.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private IAuthService _authService;

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
            
            return Ok(new {token=token});
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] UserModel userModel)
        {
            _authService.Register(userModel);
            
            return Ok(new {token=""});
        }
    }
}

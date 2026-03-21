using Authorization.Application.Handlers.Commands;
using AuthService.Application.Users;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace AuthService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            _logger.LogInformation("Received registration request for user {Username}", command.Username);
            var result = await _mediator.Send(command);
            if (result.IsFailed)
            {
                _logger.LogWarning("Registration failed for user {Username}: {Errors}", command.Username, result.Errors);
                return BadRequest(result.Errors);
            }
            var user = result.Value;
            _logger.LogInformation("User {Username} registered successfully with ID {UserId}", user.username, user.id);
            return Ok(user);
        }
    }
}

using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace AuthService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly ISender _sender = sender;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
         public IActionResult Get()
        {
            _logger.LogInformation("Request receiver");


            var user = new
            {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                Email = "john.doe@gmail.coms"
            };

            _logger.LogInformation("Generated random user {@User}", user);
            return Ok();
        }
    }
}

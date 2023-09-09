using Bakery.Application.Contracts.Identity;
using Bakery.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.Api.Controllers
{
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly IJwtManager _jwtManager;

        public JwtController(IJwtManager jwtManager)
        {
            _jwtManager = jwtManager;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("/authenticate")]
        public IActionResult Authenticate([FromHeader] string phoneNumber)
        {
            var token = _jwtManager.Authenticate(phoneNumber);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}

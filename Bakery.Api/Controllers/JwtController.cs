using Bakery.Api.Interfaces;
using Bakery.Api.Model;
using Bakery.Application.Contracts.Identity;
using Bakery.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
		public IActionResult Authenticate(Users usersdata)
		{
			var token = _jwtManager.Authenticate(usersdata);
			if (token == null)			
				return Unauthorized();			
			return Ok(token);
		}
	}
}

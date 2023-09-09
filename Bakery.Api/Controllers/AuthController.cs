using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakery.Application.Contracts.Identity;
using Bakery.Application.Models;
using Shared.Responses;

namespace Bakery.Api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("/Auth/Register")]
        public async Task<BaseResponse> RegisterAsync([FromBody] RegistrationRequestModel registrationRequestModel)
        {
            return await _authService.RegisterAsync(registrationRequestModel);
        }
        [HttpPost]
        [Route("/Auth/LoginFirstStep")]
        public async Task<LoginModel> LoginFirstStepAsync([FromHeader] string phoneNumber)
        {
            return await _authService.LoginFirstStepAsync(phoneNumber);
        }
        [HttpPost]
        [Route("/Auth/LoginSecondStep")]
        public async Task<LoginModel> LoginSecondStepAsync([FromHeader] string phoneNumber)
        {
            return await _authService.LoginSecondStepAsync(phoneNumber);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bakery.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Responses;

namespace Bakery.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<LoginModel> LoginFirstStepAsync(string phoneNumber);
        Task<LoginModel> LoginSecondStepAsync(string phoneNumber);
        Task<BaseResponse> RegisterAsync(RegistrationRequestModel registrationRequestModel);
    }
}

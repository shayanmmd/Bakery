using System.Threading.Tasks;
using Bakery.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Responses;

namespace EndPoint.AspCore.Contracts
{
    public interface IAuthRepository
    {
        public Task<BaseResponse> RegisterAsync(RegistrationRequestModel registrationRequestModel);
        public Task<LoginModel> LoginFirstStepAsync(string phoneNumber);
        public Task<LoginModel> LoginSecondStepAsync(string phoneNumber);
    }
}